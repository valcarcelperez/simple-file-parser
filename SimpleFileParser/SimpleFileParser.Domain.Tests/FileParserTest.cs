using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SimpleFileParser.Domain.Tests
{
    [TestClass]
    public class FileParserTest
    {
        private FileParser _target;
        private FakePrinter _printer;
        private string _testFilesFolder;

        [TestInitialize]
        public void Initialize()
        {
            _testFilesFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _testFilesFolder = Path.Combine(_testFilesFolder, "TestFiles");

            _printer = new FakePrinter();
            _target = new FileParser(_printer);
        }

        [TestMethod]
        public void Given_a_valid_file_Should_print_the_value_of_the_fourth_field()
        {
            var path = Path.Combine(_testFilesFolder, "valid-file.csv");
            _target.Parse(path);

            Assert.AreEqual(2, _printer.PrintedValues.Count);
            Assert.AreEqual("first", _printer.PrintedValues[0]);
            Assert.AreEqual("awesome", _printer.PrintedValues[1]);
        }

        [TestMethod]
        public void Given_a_filename_that_does_not_exist_Should_print_message()
        {
            var path = Path.Combine(_testFilesFolder, "a-file-that-does-not-exist.csv");
            _target.Parse(path);

            Assert.AreEqual(1, _printer.PrintedValues.Count);
            Assert.AreEqual("File 'a-file-that-does-not-exist.csv' not found", _printer.PrintedValues[0]);
        }
    }

    public class FakePrinter : IPrinter
    {
        public List<string> PrintedValues { get; } = new List<string>();

        public void Print(string text)
        {
            PrintedValues.Add(text);
        }
    }
}
