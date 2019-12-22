using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_8.Models
{
    public class SquareLessSequence : ISequence
    {
        private int _minRange;
        private int _maxRange;

        public SquareLessSequence(int minRange, int maxRange)
        {
            _minRange = minRange;
            _maxRange = maxRange;
        }

        public SquareLessSequence(SequenceDTO sequence)
        {
            _minRange = sequence.MinRange;
            _maxRange = sequence.MaxRange;
        }

        public int MinRange => _minRange;

        public int MaxRange => _maxRange;

        public IEnumerator<int> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<int>
        {
            private readonly SquareLessSequence _sequence;
            private int _current;
            private int _maxSquare;

            internal Enumerator(SquareLessSequence sequence)
            {
                _sequence = sequence;
                _current = Math.Max(_sequence.MinRange, 1);
                _maxSquare = (int)Math.Ceiling(Math.Sqrt(_sequence.MaxRange)) - 1;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                while (_current < _maxSquare)
                {
                    _current++;
                    return true;
                }
                _current = Math.Max(_sequence.MinRange, 1);

                return false;
            }

            public void Reset()
            {
                _current = Math.Max(_sequence.MinRange, 1);
            }

            public int Current
            {
                get { return _current * _current; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
    }
}
