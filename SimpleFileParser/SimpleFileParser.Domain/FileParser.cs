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
        }
    }
}
