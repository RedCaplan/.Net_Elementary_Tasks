﻿using System;
using Task1.Models.Enums;
using Task1.Models.Interfaces;

namespace Task1.Models
{
    class ChessBoardView : IBoardView
    {
        private const char WHITE_CELL_SIGN = '*';
        private const char BLACK_CELL_SIGN = ' ';
        private const string MESSAGE_HELP = @"Usages for program|Input arguments: <height> <width>";

        private IBoard _board;

        public ChessBoardView(IBoard board)
        {
            _board = board;
        }

        public ChessBoardView()
        {
            _board = new ChessBoard(new BoardSize(0,0));
        }

        public IBoard Board
        {
            get => _board;
            set => _board = value;
        }

        public void Display()
        {
            for (var row = 0; row < _board.BoardSize.Height; row++)
            {
                for (var column = 0; column < _board.BoardSize.Width; column++)
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
            Console.WriteLine(MESSAGE_HELP);
        }   
    }
}