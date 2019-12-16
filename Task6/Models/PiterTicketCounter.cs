﻿using Task6.Models.ExtensionMethods;

namespace Task6.Models
{
    public class PiterTicketCounter : TicketCounter
    {
        public PiterTicketCounter(TicketGenerator ticketGenerator) : base(ticketGenerator)
        {
        }

        public override bool IsLucky(Ticket ticket)
        {
            bool isLucky = false;
            int[] sequence = ticket.Number.ToArray(_ranks);
            int sum = 0;

            for (int i = 0; i < sequence.Length / 2; i += 2)
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