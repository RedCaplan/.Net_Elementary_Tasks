using System.Collections.Generic;
using Task6.Extensions;

namespace Task6.Models
{
    public class PiterTicketCounter : TicketCounter
    {
        public PiterTicketCounter(IEnumerable<Ticket> tickets) : base(tickets)
        {
        }

        public override bool IsLucky(Ticket ticket)
        {
            bool isLucky = false;
            int[] sequence = ticket.Number.ToArray(_ranks);
            int sum = 0;

            for (int i = 0; i < sequence.Length; i += 2)
            {
                sum += sequence[i] - sequence[i + 1];
            }

            if (sum == 0)
            {
                isLucky = true;
            }

            return isLucky;
        }
    }
}
