using Task1.Models.Enums;
using Task1.Models.Interfaces;

namespace Task1.Models
{
    class ChessBoard : IBoard
    {
        private readonly ICell[,] _board;
        private readonly BoardSize _boardSize;

        public ChessBoard(BoardSize boardSize)
        {
            _boardSize = boardSize;
            _board = new Cell[boardSize.Height, boardSize.Width];
        }

        public BoardSize BoardSize
        {
            get => _boardSize;
        }
        public ICell this[int height, int width] => _board[height, width];

        public void Build()
        {
            for (var row = 0; row < _boardSize.Height; row++)
            {
                for (var column = 0; column < _boardSize.Width; column++)
                {
                    if ((row + column) % 2 == 0) 
                    {
                        _board[row, column] = new Cell(GameColor.White);
                    }
                    else
                    {
                        _board[row, column] = new Cell(GameColor.Black);
                    }
                }
            }
        }
    }
}