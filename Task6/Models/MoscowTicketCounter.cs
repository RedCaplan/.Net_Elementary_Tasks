using System.Collections.Generic;
using Task6.Extensions;

namespace Task6.Models
{
    public class MoscowTicketCounter : TicketCounter
    {
        public MoscowTicketCounter(IEnumerable<Ticket> tickets) : base(tickets)
        {
        }

        public override bool IsLucky(Ticket ticket)
        {
            bool isLucky = false;
            int[] sequence = ticket.Number.ToArray(_ranks, (_ranks-ticket.Number.DigitArrayLength())/2);
            int sum = 0;

            for (int i = 0; i < sequence.Length / 2; i++)
            {
                sum += sequence[i] - sequence[sequence.Length - 1 - i];
            }

            if (sum == 0)
            {
                isLucky = true;
            }

            return isLucky;
        }
    }
}
