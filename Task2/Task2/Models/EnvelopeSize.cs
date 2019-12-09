using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Models
{
    public struct EnvelopeSize
    {
        public double Height;
        public double Width;

        public EnvelopeSize(double height, double width)
        {
            Height = height;
            Width = width;
        }
    }
}
