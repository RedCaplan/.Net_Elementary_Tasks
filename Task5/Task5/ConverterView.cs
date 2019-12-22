using System;

namespace Task5
{
    public class ConverterView
    {
        private const string MESSAGE_HELP = "|IntToText Converter| Input arguments: <number>";

        public ConverterView()
        {
        }

        public void Display(string message = "")
        {
            Console.WriteLine(message);
        }

        public void DisplayInstruction()
        {
            Console.WriteLine(MESSAGE_HELP);
        }

        public int GetNumber()
        {
            string[] arguments = Environment.GetCommandLineArgs();
            if (arguments.Length != 2 || arguments[1] == null)
            {
                throw new ArgumentOutOfRangeException("argument", "Must be one argument <number>");
            }
        
            return int.Parse(arguments[1]);
        }
    }
}
