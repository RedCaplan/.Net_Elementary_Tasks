using System;
using Task1.Models.Enums;
using Task1.Models.Interfaces;

namespace Task1.Models
{
    class ChessBoardView : IBoardView
    {
        private const char WHITE_CELL_SIGN = '*';
        private const char BLACK_CELL_SIGN = ' ';
        private readonly IBoard _board;
        private const string MESSAGE_HELP = @"Usages for program (Print chessboard)
                Input arguments: <height> <width>
                ```````````
                Arguments
                ```````````
                height -> The height of the chessboard to print
                width -> The width of the chessboard to print
                ```````````";


        public void Display()
        {
            for (var row = 0; row < _board.Height; row++)
            {
                for (var column = 0; column < _board.Width; column++)
                {
                    if (_board[row, column].Color == GameColor.White)
                    {
                        Console.Write(WHITE_CELL_SIGN);
                    }
                    else
                    {
                        Console.Write(BLACK_CELL_SIGN);
                    }
                }
                Console.WriteLine();
            }
        }

        public void DisplayInstruction()
        {
            Console.WriteLine(_helpMessage);
        }   

        public ChessBoardView(IBoard board)
        {
            _board = board;
        }
    }
}