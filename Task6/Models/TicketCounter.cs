using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Task6.Extensions;

namespace Task6.Models
{
    public abstract class TicketCounter
    {
        public virtual int CountLuckyTickets()
        {
            int result = 0;

            foreach (Ticket ticket in _tickets)
            {
                if (IsLucky(ticket))
                {
                    result++;
                }
            }

            return result;
        }

        public abstract bool IsLucky(Ticket ticket);


        protected readonly IEnumerable<Ticket> _tickets;
        protected readonly int _ranks;

        protected TicketCounter(IEnumerable<Ticket> tickets)
        {
            _tickets = tickets;
            _ranks = tickets.Max(t=>t.Number).DigitArrayLength();
        }
    }
}
