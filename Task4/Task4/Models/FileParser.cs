using System;
using System.IO;

namespace Task4.Models
{
    public class FileParser
    {
        public readonly string _filePath;

        public FileParser(string filePath)
        {
            _filePath = filePath;
        }

        public FileParser(FileInfo fileInfo)
        {
            _filePath = fileInfo.ToString();
        }

        public string FilePath => _filePath;

        public int LineEntryCount(string line)
        {
            using (StreamReader reader = new StreamReader(_filePath))
            {
                string currentLine = string.Empty;
                int entryCount = 0;

                while (!reader.EndOfStream)
                {
                    currentLine = reader.ReadLine();

                    int minIndex = currentLine.IndexOf(line, 0);
                    while (minIndex != -1)
                    {
                        minIndex = currentLine.IndexOf(line, minIndex + line.Length);
                        entryCount++;
                    }
                }

                return entryCount;
            }
        }

        public void ReplaceLines(string oldValue, string newValue)
        {
            FileInfo fileInfo = new FileInfo(_filePath);
            string fileBackup = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + $"-backup.txt";
            string bufferFile = Path.GetTempFileName();

            File.Copy(_filePath, $@"{fileInfo.Directory}\{fileBackup}", true);
            using (StreamReader reader = new StreamReader(_filePath))
            using (StreamWriter writer = new StreamWriter(bufferFile))
            {
                while (!reader.EndOfStream)
                {
                    string currentLine = reader.ReadLine();

                    if (currentLine.Contains(oldValue))
                    {
                        writer.WriteLine(currentLine.Replace(oldValue, newValue));
                    }
                    else
                    {
                        writer.WriteLine(currentLine);
                    }
                }
            }

            File.Delete(_filePath);
            File.Move(bufferFile, $@"{fileInfo.DirectoryName}\{fileInfo.Name}");
        }
    }
}
