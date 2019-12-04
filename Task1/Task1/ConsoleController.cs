﻿using System;
using System.Text;
using Task1.Models;
using Task1.Models.Interfaces;

namespace Task1
{
    public class ConsoleController
    {
        private const int DEFAULT_COMMANDLINE_ARGS_COUNT = 2;

        private readonly string[] _args;
        private readonly IBoardView _boardView;
        private IBoard _board;

        public ConsoleController(string[] args = null) : this(new ChessBoardView(), args)
        {
        }
        public ConsoleController(IBoardView boardView, string[] args)
        {
            _args = args ?? new string[] { };
            _boardView = boardView;
        }

        public void Run()
        {
            switch (_args.Length)
            {
                case DEFAULT_COMMANDLINE_ARGS_COUNT:
                    {
                        BuildBoard();
                        _boardView.Board = _board;
                        _boardView.Display();
                        break;
                    }
                default:
                    {
                        _boardView.DisplayInstruction();
                        break;
                    }
            }

        }

        private void BuildBoard()
        {
            int height = 0;
            int width = 0;
            try
            {
                height = int.Parse(_args[0]);
                if (height < 0)
                {
                    throw new ArgumentOutOfRangeException("height");
                }
                width = int.Parse(_args[1]);
                if (width < 0)
                {
                    throw new ArgumentOutOfRangeException("width");
                }
            }
            catch (FormatException ex)
            {

            }
            catch (OverflowException ex)
            {

            }
            catch (ArgumentOutOfRangeException ex)
            {

            }

            _board = new ChessBoard(height, width);
            _board.Build();
        }

    }
}