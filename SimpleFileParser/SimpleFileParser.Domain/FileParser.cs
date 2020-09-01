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
                    var lineCount = 0;
                    while (line != null)
                    {
                        lineCount++;
                        var isValidLine = ParseLine(line, lineCount);
                        if (!isValidLine)
                        {
                            return;
                        }   
                        
                        line = reader.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                _printer.Print($"Error while reading the file. {ex}");
            }
        }

        private bool ParseLine(string line, int lineNumber)
        {
            var fields = line.Split(_config.Delimiter);
            if (fields.Length < _config.ExpectedFieldCount)
            {
                _printer.Print($"Line #{lineNumber} is incomplete");
                return false;
            }

            _printer.Print(fields[_config.TargetField]);
            return true;
        }
    }
}
