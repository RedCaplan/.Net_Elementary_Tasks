using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7_8.Models;
using Task7_8.Models.Enums;

namespace Task7_8
{
    public class SequenceView
    {
        private const string MESSAGE_HELP = @"Usages for program 2 modes:";
        private const string MESSAGE_HELP_FIBONACCI = @"Fibonacci | Input arguments: <minRange>, <maxRange>";
        private const string MESSAGE_HELP_SQUARELESS = @"SquareLess | Input arguments: <number>";

        public SequenceView()
        {
        }

        public void Display(string message = "")
        {
            Console.WriteLine(message);
        }

        public void DisplayInstruction()
        {
            Console.WriteLine(MESSAGE_HELP);
            Console.WriteLine(MESSAGE_HELP_FIBONACCI);
            Console.WriteLine(MESSAGE_HELP_SQUARELESS);
        }

        public void DisplaySequence(ISequence sequence)
        {
            foreach (var number in sequence)
            {
                Console.WriteLine(number);
            }
        }

        public SequenceDTO GetSequence()
        {
            string[] arguments = Environment.GetCommandLineArgs().Skip(1).ToArray();
            if (arguments == null)
            {
                throw new ArgumentOutOfRangeException("arguments", "Needs at least 1 arguments");
            }

            SequenceType sequenceType = GetType(arguments);
            int minRange;
            int maxRange;

            switch (sequenceType)
            {
                case SequenceType.Fibonacci:
                    {
                        minRange = int.Parse(arguments[0]);
                        maxRange = int.Parse(arguments[1]);
                        break;
                    }
                case SequenceType.SquareLess:
                    {
                        minRange = 1;
                        maxRange = int.Parse(arguments[0]);
                        break;
                    }
                default:
                    {
                        minRange = 0;
                        maxRange = 0;
                        break;
                    }
            }

            return new SequenceDTO(sequenceType, minRange, maxRange);
        }

        private SequenceType GetType(string[] arguments)
        {
            SequenceType sequenceType;
            switch (arguments.Length)
            {
                case 1:
                    {
                        sequenceType = SequenceType.SquareLess;
                        break;
                    }
                case 2:
                    {
                        sequenceType = SequenceType.Fibonacci;
                        break;
                    }
                default:
                    {
                        sequenceType = SequenceType.None;
                        break;
                    }
            }

            return sequenceType;
        }
    }
}
