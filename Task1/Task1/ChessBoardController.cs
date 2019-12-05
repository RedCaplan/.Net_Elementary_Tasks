using System;
using System.Text;
using Task1.Models;
using Task1.Models.Interfaces;

namespace Task1
{
    public class ChessBoardController
    {
        private const int DEFAULT_COMMANDLINE_ARGS_COUNT = 2;

        private readonly string[] _args;
        private readonly IBoardView _boardView;
        private IBoard _board;

        public ChessBoardController(string[] args = null) : this(new ChessBoardView(), args)
        {
        }
        public ChessBoardController(IBoardView boardView, string[] args)
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
            BoardSize boardSize = new BoardSize(0,0);
            try
            {
               boardSize = ParseArguments();
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

            _board = new ChessBoard(boardSize);
            _board.Build();
        }

        private BoardSize ParseArguments()
        {
            int height = int.Parse(_args[0]);
            if (height < 0)
            {
                throw new ArgumentOutOfRangeException("height");
            }

            int width = int.Parse(_args[1]);
            if (width < 0)
            {
                throw new ArgumentOutOfRangeException("width");
            }

            return new BoardSize(height, width);
        }

    }
}