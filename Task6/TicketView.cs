using System;
using System.Linq;
using Serilog;
using Task6.Constants;
using Task6.Models;

namespace Task6
{
    public class TicketView
    {
        private readonly string[] _args;

        public TicketView(string[] args = null)
        {
            _args = args ?? new string[] { };
        }

        public TicketView()
        {
            _args = Environment.GetCommandLineArgs().Skip(1).ToArray();
        }

        public void Display(string message = "")
        {
            Console.WriteLine(message);
        }

        public void DisplayInstruction()
        {
            Console.WriteLine(Messages.MESSAGE_HELP);
        }


        public string GetModeFilePath()
        {
            if (_args.Length < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _args[0];
        }

        public TicketGeneratorDTO GetTicketGenerator()
        {
            int minRange = 0;
            int maxRange = 0;

            switch (_args.Length)
            {
                case Settings.DEFAULT_COMMANDLINE_ARGS_COUNT:
                {
                    Log.Information("Using default range");
                    minRange = Settings.DEFAULT_GENERATOR_MIN_RANGE;
                    maxRange = Settings.DEFAULT_GENERATOR_MAX_RANGE;
                    break;
                }
                case Settings.PATH_AND_RANGE_ARGS_COUNT:
                {
                    minRange = int.Parse(_args[1]);
                    maxRange = int.Parse(_args[2]);
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException("arguments",
                        "No mode with this number of arguments");
                }
            }
            
            return new TicketGeneratorDTO(minRange,maxRange);
        }
    }
}
