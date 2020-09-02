using SimpleFileParser.Domain;
using System;

namespace SimpleFileParser.ConsoleApp
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
