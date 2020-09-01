namespace SimpleFileParser.Domain
{
    public class FileParserConfig
    {
        public char Delimiter { get; set; }
        public int ExpectedFieldCount { get; set; }
        public int TargetField { get; set; }
    }
}
