using System;
using Task6.Models.Enums;

namespace Task6.Models
{
    public class TicketCounterFactory
    {
        public static TicketCounter Build(TicketCounterMode mode, TicketGenerator generator)
        {
            TicketCounter ticketCounter;
            switch (mode)
            {
                case TicketCounterMode.Moscow:
                {
                    ticketCounter = new MoscowTicketCounter(generator);
                    break;
                }
                case TicketCounterMode.Piter:
                {
                    ticketCounter = new PiterTicketCounter(generator);
                    break;
                }
                case TicketCounterMode.None:
                default:
                {
                    throw new ArgumentOutOfRangeException("mode",
                        "No such method of counting");
                }
            }

            return ticketCounter;
        }
    }
}
