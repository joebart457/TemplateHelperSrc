using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace template_processor.Services
{
    class ProcessingService
    {
        private SymbolResolverService _resolver = new SymbolResolverService();

        private string _sourceFolder;
        private string _destinationFolder;
        public int Process(string sourceFolder, string destFolder)
        {
            _sourceFolder = sourceFolder;
            if (!sourceFolder.EndsWith("\\") || sourceFolder.EndsWith("/"))
            {
                _sourceFolder = _sourceFolder + "\\";
            }
            _destinationFolder = destFolder;

            foreach (string file in Directory.EnumerateFileSystemEntries(sourceFolder, "*", SearchOption.AllDirectories))
            {
                if (Directory.Exists(file))
                {
                    // If it is a directory, try to create it if it doesn't exist in destFolder

                    HandleDirectory(file);
                } else
                {
                    HandleFile(file);
                }

            }
            return 0;
        }

        private string SwitchPath(string filepath)
        {
            string truncatedPath = filepath.Replace(_sourceFolder, "");
            return Path.Combine(_destinationFolder, truncatedPath);
        }

        private void HandleDirectory(string dir)
        {
            string newDirName = SwitchPath(dir);
            _resolver.Resolve(ref newDirName);
            Directory.CreateDirectory(newDirName);
        }

        private void HandleFile(string filepath)
        {
            string filename = SwitchPath(filepath);
            _resolver.Resolve(ref filename);
            if (File.Exists(filename))
            {
                throw new Exception($"Unable to process file {filename} file already exists");
            }

            string rawText = File.ReadAllText(filepath);
            _resolver.Resolve(ref rawText);
            File.WriteAllText(filename, rawText);
        }
    }
}
