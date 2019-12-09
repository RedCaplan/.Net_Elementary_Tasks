using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Models
{
    public class Envelope : IComparable<Envelope>
    {
        private readonly EnvelopeSize _envelopeSize;

        public Envelope(double height, double width)
        {
            _envelopeSize.Height = Math.Max(height,width);
            _envelopeSize.Width = Math.Min(height,width);
        }

        public Envelope(EnvelopeSize envelopeSize)
        {
            _envelopeSize = envelopeSize;
        }

        public EnvelopeSize EnvelopeSize => _envelopeSize;


        public int CompareTo(Envelope other)
        {
            if (_envelopeSize.Height > other.EnvelopeSize.Height && _envelopeSize.Width > other.EnvelopeSize.Width)
            {
                return 1;
            }
            else if (other.EnvelopeSize.Height > _envelopeSize.Height && other.EnvelopeSize.Width > _envelopeSize.Width)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
