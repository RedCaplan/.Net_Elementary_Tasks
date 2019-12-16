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
        private const int DEFAULT_MIN_RANGE = 0;
        private const int DEFAULT_MAX_RANGE = 999999;
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

            if (_args.Length != DEFAULT_COMMANDLINE_ARGS_COUNT
                && _args.Length != PATH_AND_RANGE_ARGS_COUNT)
            {
                _ticketView.DisplayInstruction();

                return;
            }

            string message = "";
            try
            {
                TicketGenerator ticketGenerator;
                if (_args.Length == PATH_AND_RANGE_ARGS_COUNT)
                {
                    ticketGenerator = ParseTicketGenerator();
                }
                else
                {
                    ticketGenerator = new TicketGenerator(DEFAULT_MIN_RANGE, DEFAULT_MAX_RANGE);
                }
                Log.Information("Getted range: {minRange}, {maxRange}",
                    ticketGenerator.MinRange, ticketGenerator.MaxRange);

                TicketCounter ticketCounter = ParseTicketCounter(ticketGenerator);
                int luckyTickets = ticketCounter.CountLuckyTickets();
                message = string.Format("Lucky tickets count: {0}", luckyTickets);

                Log.Information("LuckyTickets count: {luckyTickets}", luckyTickets);
            }
            catch(FormatException ex)
            {
                message = ex.Message;
                Log.Error(ex, "Exception thrown");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                message = ex.Message;
                Log.Error(ex, "Exception thrown");
            }
            catch (OverflowException ex)
            {
                message = ex.Message;
                Log.Error(ex, "Exception thrown");
            }
            catch (FileNotFoundException ex)
            {
                message = ex.Message;
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
            TicketCounter ticketCounter;

            using (StreamReader streamReader = new StreamReader(path))
            {
                mode = streamReader.ReadLine()?.ToLower();
                Log.Information("Getted mode: {mode}", mode);
            }

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
                        throw new ArgumentOutOfRangeException("mode", "No such method of counting");
                    }
            }

            return ticketCounter;
        }

        private TicketGenerator ParseTicketGenerator()
        {
            int minRange = int.Parse(_args[1]);
            int maxRange = int.Parse(_args[2]);

            if (minRange < 0)
            {
                throw new ArgumentOutOfRangeException("minRange", "Must be positive");
            }
            if (maxRange < 0)
            {
                throw new ArgumentOutOfRangeException("maxRange", "Must be positive");
            }

            if (minRange > maxRange)
            {
                throw new ArgumentOutOfRangeException("range", "The Minimum range must be greater than or equal to the maximum");
            }

            return new TicketGenerator(minRange, maxRange);
        }
    }
}
