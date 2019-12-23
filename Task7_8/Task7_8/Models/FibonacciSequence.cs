using System.Collections;
using System.Collections.Generic;

namespace Task7_8.Models
{
    public class FibonacciSequence : ISequence
    {
        private int _minRange;
        private int _maxRange;

        public FibonacciSequence(int minRange, int maxRange)
        {
            _minRange = minRange;
            _maxRange = maxRange;
        }

        public FibonacciSequence(SequenceDTO sequence)
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
            private readonly FibonacciSequence _sequence;
            private int _current;
            private int _previous;

            internal Enumerator(FibonacciSequence sequence)
            {
                _sequence = sequence;
                _current = 1;
                _previous = 0;
                Initialize();
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                while (_previous + _current < _sequence.MaxRange)
                {
                    int temp = _current;
                    _current += _previous;
                    _previous = temp;

                    return true;
                }
                _current = 1;
                _previous = 0;

                return false;
            }

            public void Reset()
            {
                Initialize();
            }

            public int Current
            {
                get { return _current; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            private void Initialize()
            {
                _current = 1;
                _previous = 0;

                while (_current + _previous < _sequence.MinRange)
                {
                    int temp = _current;
                    _current += _previous;
                    _previous = temp;
                }
            }
        }
    }
}
