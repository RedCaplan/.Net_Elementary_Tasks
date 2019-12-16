﻿using Task6.Models.ExtensionMethods;

namespace Task6.Models
{
    public class MoscowTicketCounter : TicketCounter
    {
        public MoscowTicketCounter(TicketGenerator ticketGenerator) : base(ticketGenerator)
        {
        }

        public override bool IsLucky(Ticket ticket)
        {
            bool isLucky = false;
            int[] sequence = ticket.Number.ToArray(_ranks);
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