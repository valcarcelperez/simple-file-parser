using SimpleFileParser.Domain;
using System;
using System.IO;

namespace SimpleFileParser.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Path argument is missing. Please pass a path argument.");
                Environment.ExitCode = 1;
                return;
            }

            var path = args[0];
            if (!File.Exists(path))
            {
                // Note: FileParser is already validating the file but this is a better place.
                Console.WriteLine($"File '{path}' not found");
                Environment.ExitCode = 1;
                return;
            }

            var config = new FileParserConfig { Delimiter = ',', TargetField = 3, ExpectedFieldCount = 5 };
            var printer = new ConsolePrinter();

            var fileParser = new FileParser(printer, config);
            fileParser.Parse(path);
        }
    }
}
