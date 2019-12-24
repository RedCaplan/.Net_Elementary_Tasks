using System;
using System.Collections.Generic;
using Task6.Models.Enums;

namespace Task6.Models
{
    public class TicketCounterFactory
    {
        public static TicketCounter Build(TicketCounterMode mode, IEnumerable<Ticket> tickets)
        {
            TicketCounter ticketCounter;
            switch (mode)
            {
                case TicketCounterMode.Moscow:
                {
                    ticketCounter = new MoscowTicketCounter(tickets);
                    break;
                }
                case TicketCounterMode.Piter:
                {
                    ticketCounter = new PiterTicketCounter(tickets);
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
