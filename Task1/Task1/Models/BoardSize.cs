using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Models
{
    public struct BoardSize
    {
        public readonly int Height;
        public readonly int Width;

        public BoardSize(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}
