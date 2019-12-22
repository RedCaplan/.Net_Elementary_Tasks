using Serilog;
using System;
using System.IO;
using Task4.Models;
using Task4.Models.Enums;

namespace Task4
{
    public class FileParserController
    {
        private readonly FileParserView _fileParserView;

        public FileParserController(FileParserView fileParserView)
        {
            _fileParserView = fileParserView;
        }

        public FileParserController(string[] args = null) : this(new FileParserView())
        {
        }

        public void Run()
        {
            try
            {
                FileParserDTO parserDTO = _fileParserView.GetFileParser();
                FileParser fileParser = new FileParser(parserDTO.FilePath);

                Log.Information("New file parser: {path}, {mode}", parserDTO.FilePath, parserDTO.ParseMode);

                string message = string.Empty;
                switch (parserDTO.ParseMode)
                {
                    case ParseMode.CountLineEntries:
                        {
                            int linesCount = fileParser.LineEntryCount(parserDTO.FindLine);

                            Log.Information("File line entries count: {file}, \"{line}\", {count}",
                                fileParser.FilePath, parserDTO.FindLine, linesCount);

                            message = string.Format("Lines count: {0}", linesCount);
                            break;
                        }
                    case ParseMode.ReplaceLines:
                        {
                            fileParser.ReplaceLines(parserDTO.FindLine, parserDTO.ReplaceLine);

                            Log.Information("File line replaced: {file}, \"{oldLine}\", \"{newLine}\"",
                                 fileParser.FilePath, parserDTO.FindLine, parserDTO.ReplaceLine);

                            message = "Lines have been replaced";
                            break;
                        }
                    default:
                        {
                            _fileParserView.DisplayInstruction();
                            break;
                        }
                }
                _fileParserView.Display(message);
            }
            catch (Exception ex) when (ex is FormatException
                                       || ex is ArgumentOutOfRangeException
                                       || ex is OverflowException
                                       || ex is FileNotFoundException)
            {
                _fileParserView.DisplayInstruction();
                Log.Error(ex, "Exception thrown");
            }
        }
    }
}
