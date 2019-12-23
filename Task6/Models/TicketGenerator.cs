using System;
using System.Collections;
using System.Collections.Generic;

namespace Task6.Models
{
    public class TicketGenerator : IEnumerable<Ticket>
    {
        private readonly int _minRange;
        private readonly int _maxRange;

        private TicketGenerator(int minRange, int maxRange)
        {
            _minRange = minRange;
            _maxRange = maxRange;
        }

        public static TicketGenerator Build(int minRange, int maxRange)
        {
            if (minRange < 0)
            {
                throw new ArgumentOutOfRangeException("minRange",
                    "Must be positive");
            }
            if (maxRange < 0)
            {
                throw new ArgumentOutOfRangeException("minRange",
                    "Must be positive");
            }
            if (minRange >= maxRange)
            {
                throw new ArgumentOutOfRangeException("Range",
                    "minRange is greater than the maxRange");
            }

            return new TicketGenerator(minRange, maxRange);
        }

        public static TicketGenerator Build(TicketGeneratorDTO ticketGeneratorDTO)
        {
            return Build(ticketGeneratorDTO.MinRange, ticketGeneratorDTO.MaxRange);
        }

        public int MinRange => _minRange;

        public int MaxRange => _maxRange;

        public IEnumerator<Ticket> GetEnumerator()
        {
            for (int i = _minRange; i <= _maxRange; i++)
            {
                yield return new Ticket(i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
