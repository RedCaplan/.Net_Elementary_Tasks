using System;
using System.IO;
using Serilog;
using Task6.Models;
using Task6.Models.Constants;

namespace Task6
{
    public class TicketController
    {
        private const int DEFAULT_COMMANDLINE_ARGS_COUNT = 1;
        private const int PATH_AND_RANGE_ARGS_COUNT = 3;

        private readonly string[] _args;
        private readonly TicketView _ticketView;

        public TicketController(TicketView ticketView, string[] args)
        {
            _args = args ?? new string[] { };
            _ticketView = ticketView;
        }
        public TicketController(string[] args = null) : this(new TicketView(), args)
        {
        }

        public void Run()
        {
            Log.Information("New start with args: {args}", _args);

            string message = string.Empty;
            try
            {
                TicketGenerator ticketGenerator = ParseTicketGenerator();
                TicketCounter ticketCounter = ParseTicketCounter(ticketGenerator);
                int luckyTickets = ticketCounter.CountLuckyTickets();

                message = string.Format("Lucky tickets count: {0}", luckyTickets);
                Log.Information("LuckyTickets count: {luckyTickets}", luckyTickets);
            }
            catch (FormatException ex)
            {
                Log.Error(ex, "Exception thrown");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Log.Error(ex, "Exception thrown");
            }
            catch (OverflowException ex)
            {
                Log.Error(ex, "Exception thrown");
            }
            catch (FileNotFoundException ex)
            {
                Log.Error(ex, "Exception thrown");
            }

            _ticketView.Display(message);
        }

        private TicketCounter ParseTicketCounter(TicketGenerator generator)
        {
            string path = _args[0];
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            string mode;
            using (StreamReader streamReader = new StreamReader(path))
            {
                mode = streamReader.ReadLine()?.ToLower();
                Log.Information("Getted mode: {mode}", mode);
            }

            TicketCounter ticketCounter;
            switch (mode)
            {
                case TicketCounterNames.MOSCOW:
                    {
                        ticketCounter = new MoscowTicketCounter(generator);
                        break;
                    }
                case TicketCounterNames.PITER:
                    {
                        ticketCounter = new PiterTicketCounter(generator);
                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException("mode",
                            "No such method of counting");
                    }
            }

            return ticketCounter;
        }

        private TicketGenerator ParseTicketGenerator()
        {
            int minRange = 0;
            int maxRange = 0;

            switch (_args.Length)
            {
                case DEFAULT_COMMANDLINE_ARGS_COUNT:
                    {
                        Log.Information("Using default range");
                        minRange = Settings.DEFAULT_GENERATOR_MIN_RANGE;
                        maxRange = Settings.DEFAULT_GENERATOR_MAX_RANGE;
                        break;
                    }
                case PATH_AND_RANGE_ARGS_COUNT:
                    {
                        minRange = int.Parse(_args[1]);
                        maxRange = int.Parse(_args[2]);
                        break;
                    }
                default:
                    {
                        _ticketView.DisplayInstruction();
                        throw new ArgumentOutOfRangeException("arguments",
                            "No mode with this number of arguments");
                    }
            }

            return TicketGenerator.Build(minRange,maxRange);
        }
    }
}
