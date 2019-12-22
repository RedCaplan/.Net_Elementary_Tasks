using System;
using System.Linq;
using Task4.Models;
using Task4.Models.Enums;

namespace Task4
{
    public class FileParserView
    {
        private const string MESSAGE_HELP = @"Usages for program 2 modes:";
        private const string MESSAGE_HELP_COUNT_LINES = @"Count line entries | Input arguments: <filepath>, <line>";
        private const string MESSAGE_HELP_REPLACE_LINES = @"Replace lines | Input arguments: <filepath>, <oldLine>, <newLine>";

        public void Display(string message = "")
        {
            Console.WriteLine(message);
        }

        public void DisplayInstruction()
        {
            Console.WriteLine(MESSAGE_HELP);
            Console.WriteLine(MESSAGE_HELP_COUNT_LINES);
            Console.WriteLine(MESSAGE_HELP_REPLACE_LINES);
        }

        public FileParserDTO GetFileParser()
        {
            string[] arguments = Environment.GetCommandLineArgs().Skip(1).ToArray();
            if (arguments == Environment.GetCommandLineArgs())
            {
                throw new ArgumentOutOfRangeException("arguments", "Needs at least 2 arguments");
            }

            if (arguments.Length < 1 || arguments.Length > 3)
            {
                throw new ArgumentOutOfRangeException("arguments", "Fewer arguments needed");
            }

            ParseMode parseMode = GetParseMode(arguments);
            string filePath = arguments[0];
            string findLine = arguments[1];
            string replaceLine = string.Empty;
            if (parseMode == ParseMode.ReplaceLines)
            {
                replaceLine = arguments[2];
            }

            return new FileParserDTO(parseMode, filePath, findLine, replaceLine);
        }

        private ParseMode GetParseMode(string[] arguments)
        {
            ParseMode parseMode;
            switch (arguments.Length)
            {
                case 2:
                    {
                        parseMode = ParseMode.CountLineEntries;
                        break;
                    }
                case 3:
                    {
                        parseMode = ParseMode.ReplaceLines;
                        break;
                    }
                default:
                    {
                        parseMode = ParseMode.None;
                        break;
                    }
            }

            return parseMode;
        }
    }
}
