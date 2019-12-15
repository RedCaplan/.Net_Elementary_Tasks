using Task6.Models.ExtensionMethods;

namespace Task6.Models
{
    public abstract class TicketCounter
    {
        protected readonly TicketGenerator _ticketGenerator;
        protected readonly int _ranks;

        protected TicketCounter(TicketGenerator ticketGenerator)
        {
            _ticketGenerator = ticketGenerator;
            _ranks = ticketGenerator.MaxRange.DigitArrayLength();
        }

        public virtual int CountLuckyTickets()
        {
            int result = 0;

            foreach (Ticket ticket in _ticketGenerator)
            {
                if (IsLucky(ticket))
                {
                    result++;
                }
            }

            return result;
        }

        public abstract bool IsLucky(Ticket ticket);
    }
}
