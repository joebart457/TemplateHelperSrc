using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Models;
using Template.Frontend.Models.Constants.Enums;

namespace Template.Frontend.Tasks
{
    class TemplateCreationTask
    {
        private string _templateDirectory;
        private string _outputDirectory;
        private bool _overwrite;
        private List<SymbolMacro> _macros;

        public TemplateCreationTask(string templateDirectory, string outputDirectory, string sandboxDirectory, bool runForSandbox, bool overwrite, List<SymbolMacro> macros)
        {
            _templateDirectory = templateDirectory;
            _outputDirectory = runForSandbox? sandboxDirectory : outputDirectory;
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
            return Directory.GetFileSystemEntries(_templateDirectory, "*", SearchOption.AllDirectories).Length;
        }

        private void ValidateNoCollisions()
        {
            foreach (string file in Directory.EnumerateFileSystemEntries(_templateDirectory, "*", SearchOption.AllDirectories))
            {

                string potentialDir = SwitchPath(file);
                if (Directory.Exists(file))
                {
                    if (Directory.Exists(potentialDir))
                    {
                        // Directories will only be added to, not overwritten so we don't have to throw here
                        //throw new Exception($"{potentialDir} already exists. Please run with 'Allow overwrite' option to continue");
                    }
                }
                else
                {
                    if (File.Exists(potentialDir))
                    {
                        throw new Exception($"{potentialDir} already exists. Please run with 'Allow overwrite' option to continue");
                    }
                }

            }

        }

        public void Execute(IProgress<int> progress)
        {

            if (!_templateDirectory.EndsWith("\\") || _templateDirectory.EndsWith("/"))
            {
                _templateDirectory = _templateDirectory + "\\";
            }

            if (!_overwrite)
            {
                ValidateNoCollisions();
            }
            int counter = 0;
            foreach (string file in Directory.EnumerateFileSystemEntries(_templateDirectory, "*", SearchOption.AllDirectories))
            {
                if (Directory.Exists(file))
                {
                    // If it is a directory, try to create it if it doesn't exist in destFolder

                    HandleDirectory(file);
                }
                else
                {
                    HandleFile(file);
                }
                progress.Report(++counter);
            }
        }

        private string SwitchPath(string filepath)
        {
            string truncatedPath = filepath.Replace(_templateDirectory, "");
            return Path.Combine(_outputDirectory, truncatedPath);
        }

        private void HandleDirectory(string dir)
        {
            string newDirName = SwitchPath(dir);
            Resolve(ref newDirName);
            Directory.CreateDirectory(newDirName);
        }

        private void HandleFile(string filepath)
        {
            string filename = SwitchPath(filepath);
            Resolve(ref filename);
            if (!_overwrite && File.Exists(filename))
            {
                throw new Exception($"Unable to process file {filename} file already exists");
            }

           
            File.WriteAllLines(filename, ResolveFile(filepath));
        }

        private List<string> ResolveFile(string filepath)
        {
            var lines = File.ReadAllLines(filepath);


            List<string> resolvedLines = new List<string>();
            foreach(string line in lines)
            {
                resolvedLines.AddRange(ResolveLine(line));
            }
            return resolvedLines;

        }

        private List<string> ResolveLine(string line)
        {
            List<string> resolvedLines = new List<string>();
            foreach (SymbolMacro macro in _macros)
            {
                if (line.Contains(macro.Symbol))
                {
                    if (macro.Type == ParameterTypeEnum.CommaDelimitedList)
                    {
                        foreach (string value in macro.Value.Split(","))
                        {
                            resolvedLines.AddRange(ResolveLine(line.Replace(macro.Symbol, value)));
                        }
                        return resolvedLines;
                    }
                    else if (macro.Fn != null) {
                        line = line.Replace(macro.Symbol, macro.Fn(_macros)); 
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


        private void Resolve(ref string str)
        {
            foreach (SymbolMacro macro in _macros)
            {         
                str = str.Replace(macro.Symbol, macro.Value);
            }
        }
    }
}
