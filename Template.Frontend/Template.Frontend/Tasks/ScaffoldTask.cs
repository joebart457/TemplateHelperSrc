using Mochj.Builders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Models;
using Template.Frontend.Models.Constants.Enums;
using Template.Frontend.Services;

namespace Template.Frontend.Tasks
{

    class SymbolicFileSystemEntry
    {
        public bool IsFolder { get; set; }
        public string Symbol { get; set; }
        public string ActualFilePath { get; set; }
        public List<SymbolicFileSystemEntry> Children { get; set; }

        public List<SymbolMacro> ListItemMacros = new List<SymbolMacro>();
        public SymbolicFileSystemEntry Copy()
        {
            return new SymbolicFileSystemEntry
            {
                IsFolder = IsFolder,
                Symbol = Symbol,
                ActualFilePath = ActualFilePath,
                Children = Children.Select(x => x.Copy()).ToList(),
                ListItemMacros = ListItemMacros.Select(x => x).ToList()
            };
        }

        public SymbolicFileSystemEntry Replace(string symbol, string value)
        {
            Symbol = Symbol.Replace(symbol, value);
            return this;
        }

        public SymbolicFileSystemEntry ReplaceInChildren(string symbol, string value)
        {
            Children = Children.Select(x =>
            {
                var child = x.Replace(symbol, value);
                child.ReplaceInChildren(symbol, value);
                return child;
            }).ToList();
            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"{Symbol} => {ActualFilePath}\n");
            foreach (var child in Children)
            {
                sb.Append(child);
            }
            return sb.ToString();
        }
    }
    class ScaffoldTask
    {
        private const string ScriptIndicator = "%%%";

        private string _templateDirectory;
        private string _outputDirectory;
        private bool _overwrite;
        private List<SymbolMacro> _macros = new List<SymbolMacro>();

        private List<SymbolMacro> _currentListItemSymbols = new List<SymbolMacro>();

        private Mochj._Storage.Environment _environment = new Mochj._Storage.Environment(DefaultEnvironmentBuilder.Default);

        private IProgress<int> _progress;

        public ScaffoldTask(int projectId, string outputDirectory, bool runForSandbox, bool overwrite, List<SymbolMacro> macros)
        {
            var project = ContextService.ProjectRepository.GetProject(projectId);
            var libraries = ContextService.DependencyRepository.GetAllDependenciesForProject(projectId);

            foreach(var library in libraries)
            {
                if (Path.GetExtension(library.Path).ToLower() == ".dll")
                {
                    Mochj._Interpreter.Helpers.LoadFileHelper.LoadFromAssembly(_environment, library.Path);
                } else
                {
                    Mochj._Interpreter.Helpers.LoadFileHelper.LoadFromRawCode(_environment, library.Path);
                }
            }

            _templateDirectory = project.InputDirectory;
            _outputDirectory = runForSandbox ? project.SandboxDirectory : outputDirectory;
            _macros = macros;
            _overwrite = overwrite;
        }
        public bool Validate(out string message)
        {
            if (!Directory.Exists(_templateDirectory))
            {
                message = $"Template Directory {_templateDirectory} does not exist";
                return false;
            }
            if (!Directory.Exists(_outputDirectory))
            {
                message = $"Output Directory {_outputDirectory} does not exist";
                return false;
            }

            if (_macros == null || !_macros.Any())
            {
                message = "Macro list was null or empty";
                return false;
            }
            message = "";
            return true;
        }


        public int Estimate()
        {
            var symbolicFileSystemEntries = ResolveDir(_templateDirectory);
            List<SymbolicFileSystemEntry> resolvedEntries = new List<SymbolicFileSystemEntry>();

            foreach (var entry in symbolicFileSystemEntries)
            {
                resolvedEntries.AddRange(Resolve(entry, _macros));
            }
            return resolvedEntries.Count();
        }

        public void Execute(IProgress<int> progress)
        {
            _progress = progress;

            var symbolicFileSystemEntries = ResolveDir(_templateDirectory);
            List<SymbolicFileSystemEntry> resolvedEntries = new List<SymbolicFileSystemEntry>();

            foreach (var entry in symbolicFileSystemEntries)
            {
                resolvedEntries.AddRange(Resolve(entry, _macros));
            }

            if (!_overwrite)
            {
                foreach (var entry in resolvedEntries)
                {
                    if (File.Exists(entry.Symbol) || Directory.Exists(entry.Symbol))
                    {
                        throw new Exception($"path {entry.Symbol} already exists. Run with 'overwrite' option to overwrite");
                    }
                }
            }

            int progressCounter = 0;
            foreach (var entry in resolvedEntries)
            {
                CreateContent(entry, new List<SymbolMacro>());
                _progress.Report(++progressCounter);
            }
        }

        public void CreateContent(SymbolicFileSystemEntry entry, List<SymbolMacro> listItemMacros)
        {

            var temp = listItemMacros.Select(x => x).ToList();
            temp.AddRange(entry.ListItemMacros);

            if (entry.IsFolder)
            {
                Directory.CreateDirectory(entry.Symbol);
                foreach (var child in entry.Children)
                {
                    CreateContent(child, temp);
                }
            }
            else
            {
                // It is a file, so copy over and macro out the content

                var lines = ResolveFile(entry.ActualFilePath, temp);
                var finalLines = ResolveScripts(lines);
                File.WriteAllLines(entry.Symbol, finalLines);
            }
        }


        private List<string> ResolveScripts(List<string> lines)
        {
            List<string> final = new List<string>();
            foreach (string line in lines)
            {
                if (line.StartsWith(ScriptIndicator))
                {
                    var interpreter = new Mochj._Interpreter.Interpreter(_environment);
                    var parser = new Mochj._Parser.ItemizedParser();
                    Mochj.Models.QualifiedObject result = parser.ParseExpression(line.Substring(ScriptIndicator.Length)).Visit(interpreter);
                    final.Add(result.Object != null? result.Object.ToString() : "null");
                }
                else
                {
                    final.Add(line);
                }
            }
            return final;
        }

        private List<string> ResolveFile(string filepath, List<SymbolMacro> listItemMacros)
        {
            var lines = File.ReadAllLines(filepath);


            List<string> resolvedLines = new List<string>();
            foreach (string line in lines)
            {
                resolvedLines.AddRange(ResolveLine(line, listItemMacros));
            }
            return resolvedLines;

        }

        private List<string> ResolveLine(string line, List<SymbolMacro> listItemMacros)
        {
            List<string> resolvedLines = new List<string>();

            foreach (var macro in listItemMacros)
            {
                line = line.Replace(macro.Symbol, macro.Value);
            }

            foreach (SymbolMacro macro in _macros)
            {
                if (line.Contains(macro.Symbol))
                {
                    if (macro.Type == ParameterTypeEnum.CommaDelimitedList)
                    {
                        foreach (string value in macro.Value.Split(','))
                        {
                            resolvedLines.AddRange(ResolveLine(line.Replace(macro.Symbol, value), new List<SymbolMacro>()));
                        }
                        return resolvedLines;
                    }
                    else
                    {
                        line = line.Replace(macro.Symbol, macro.Value);
                    }
                }
            }
            resolvedLines.Add(line);

            return resolvedLines;
        }


        public List<SymbolicFileSystemEntry> Resolve(SymbolicFileSystemEntry e, List<SymbolMacro> macros)
        {
            var entry = e.Copy();

            List<SymbolicFileSystemEntry> resolvedEntries = new List<SymbolicFileSystemEntry>();

            foreach (var macro in _currentListItemSymbols)
            {
                entry.Symbol = entry.Symbol.Replace(macro.Symbol, macro.Value);
            }

            bool includedListMacro = false;
            foreach (var macro in macros)
            {
                if (entry.Symbol.Contains(macro.Symbol))
                {
                    if (macro.Type == ParameterTypeEnum.CommaDelimitedList)
                    {
                        includedListMacro = true;
                        foreach (string value in macro.Value.Split(','))
                        {
                            var listItemMacro = new SymbolMacro { Symbol = $"${macro.Symbol}", Value = value, Type = ParameterTypeEnum.Text };
                            _currentListItemSymbols.Add(listItemMacro);
                            var newEntry = entry.Copy();
                            entry.ListItemMacros.AddRange(_currentListItemSymbols);
                            newEntry.Replace(macro.Symbol, value);
                            newEntry.ReplaceInChildren(listItemMacro.Symbol, listItemMacro.Value);
                            newEntry.ReplaceInChildren(macro.Symbol, value);

                            resolvedEntries.AddRange(Resolve(newEntry, macros.Where(x => x != macro).ToList()));
                            _currentListItemSymbols.Remove(listItemMacro);
                        }
                        continue;
                    }
                    else
                    {
                        entry.Symbol = entry.Symbol.Replace(macro.Symbol, macro.Value);
                    }
                }
            }

            if (!includedListMacro)
            {
                resolvedEntries.Add(entry);


                List<SymbolicFileSystemEntry> resolvedChildren = new List<SymbolicFileSystemEntry>();

                foreach (var child in entry.Children)
                {
                    resolvedChildren.AddRange(Resolve(child, macros));
                }
                entry.Children = resolvedChildren;
            }



            return resolvedEntries;
        }

        public List<SymbolicFileSystemEntry> ResolveDir(string directory)
        {

            List<SymbolicFileSystemEntry> entries = new List<SymbolicFileSystemEntry>();

            if (!Directory.Exists(directory))
            {
                return entries;
            }

            foreach (string entry in Directory.EnumerateFileSystemEntries(directory, "*", SearchOption.TopDirectoryOnly))
            {
                entries.Add(new SymbolicFileSystemEntry { IsFolder = Directory.Exists(entry), ActualFilePath = entry, Symbol = entry.Replace(_templateDirectory, _outputDirectory), Children = ResolveDir(entry) });

            }
            return entries;
        }


    }
}
