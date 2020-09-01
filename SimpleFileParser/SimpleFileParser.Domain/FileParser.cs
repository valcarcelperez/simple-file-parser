using System;
using System.IO;

namespace SimpleFileParser.Domain
{
    public class FileParser
    {
        private IPrinter _printer;
        private FileParserConfig _config;

        public FileParser(IPrinter printer, FileParserConfig config)
        {
            _printer = printer;
            _config = config;
        }

        public void Parse(string path)
        {
            if (!File.Exists(path))
            {
                _printer.Print($"File '{path}' not found");
                return;
            }

            ReadFile(path);
        }

        private void ReadFile(string path)
        {
            try
            {
                using (var reader = new StreamReader(path))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        ParseLine(line);
                        line = reader.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                _printer.Print($"Error while reading the file. {ex}");
            }
        }

        private void ParseLine(string line)
        {
            var fields = line.Split(_config.Delimiter);
            _printer.Print(fields[_config.TargetField]);
        }
    }
}
