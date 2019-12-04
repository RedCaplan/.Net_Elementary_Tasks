using Task1.Models.Enums;
using Task1.Models.Interfaces;

namespace Task1.Models
{
    class Cell : ICell
    {
        public GameColor Color { get; }

        public Cell(GameColor color)
        {
            Color = color;
        }
    }
}