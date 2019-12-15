using System.Collections;
using System.Collections.Generic;

namespace Task6.Models
{
    public class TicketGenerator : IEnumerable<Ticket>
    {
        private readonly int _minRange;
        private readonly int _maxRange;

        public TicketGenerator(int minRange, int maxRange)
        {
            _minRange = minRange;
            _maxRange = maxRange;
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
