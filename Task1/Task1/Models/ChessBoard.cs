using System;
using Task1.Models.Enums;
using Task1.Models.Interfaces;

namespace Task1.Models
{
    class ChessBoard : IBoard
    {
        private readonly ICell[,] board;

        public ChessBoard(int height, int width)
        {
            Height = Math.Max(height, 0);
            Width = Math.Max(width, 0);
            board = new Cell[Height, Width];
        }

        public int Height { get; }
        public int Width { get; }

        public ICell this[int height, int width] => board[height, width];

        public void Build()
        {
            for (var row = 0; row < Height; row++)
            {
                for (var column = 0; column < Width; column++)
                {
                    if ((row + column) % 2 == 0) 
                    {
                        board[row, column] = new Cell(GameColor.White);
                    }
                    else
                    {
                        board[row, column] = new Cell(GameColor.Black);
                    }
                }
            }
        }
    }
}