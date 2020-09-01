namespace SimpleFileParser.Domain
{

    public class FileParser
    {
        private IPrinter _printer;

        public FileParser(IPrinter printer)
        {
            _printer = printer;
        }

        public void Parse(string path)
        {
        }
    }
}
