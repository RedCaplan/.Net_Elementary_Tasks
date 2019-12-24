using System;
using System.IO;
using Serilog;
using Task6.Models;
using Task6.Models.Enums;

namespace Task6
{
    public class TicketController
    {
        private readonly TicketView _ticketView;

        public TicketController(TicketView ticketView)
        {
            _ticketView = ticketView;
        }

        public void Run()
        {
            string message = string.Empty;
            try
            {
                TicketGeneratorDTO generatorDTO = _ticketView.GetTicketGenerator();
                TicketGenerator ticketGenerator = TicketGenerator.Build(generatorDTO);
                TicketCounterMode mode = GetTicketCounterMode();
                TicketCounter ticketCounter = TicketCounterFactory.Build(mode,ticketGenerator);
                int luckyTickets = ticketCounter.CountLuckyTickets();

                message = string.Format("Lucky tickets count: {0}", luckyTickets);
                Log.Information("LuckyTickets count: {luckyTickets}", luckyTickets);
            }
            catch (FormatException ex)
            {
                _ticketView.DisplayInstruction();
                Log.Error(ex, "Exception thrown");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _ticketView.DisplayInstruction();
                Log.Error(ex, "Exception thrown");
            }
            catch (OverflowException ex)
            {
                _ticketView.DisplayInstruction();
                Log.Error(ex, "Exception thrown");
            }
            catch (FileNotFoundException ex)
            {
                _ticketView.DisplayInstruction();
                Log.Error(ex, "Exception thrown");
            }

            _ticketView.Display(message);
        }

        private TicketCounterMode GetTicketCounterMode()
        {
            string path = _ticketView.GetModeFilePath();
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            string mode;
            using (StreamReader streamReader = new StreamReader(path))
            {
                mode = streamReader.ReadLine();
            }
            Enum.TryParse(mode, out TicketCounterMode ticketCounterMode);
            Log.Information("Getted mode: {mode}", ticketCounterMode);

            return ticketCounterMode;
        }
    }
}
