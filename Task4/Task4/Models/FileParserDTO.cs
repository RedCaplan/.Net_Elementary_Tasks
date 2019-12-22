using Task4.Models.Enums;

namespace Task4.Models
{
    public class FileParserDTO
    {
        public ParseMode ParseMode { get; }

        public string FilePath { get; }

        public string FindLine { get; }

        public string ReplaceLine { get; }

        public FileParserDTO(ParseMode mode, string filePath, string findLine, string replaceLine = "")
        {
            ParseMode = mode;
            FilePath = filePath;
            FindLine = findLine;
            ReplaceLine = replaceLine;
        }
    }
}
