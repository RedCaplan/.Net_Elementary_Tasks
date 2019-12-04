using System;
using System.Text;
using Task1.Models;
using Task1.Models.Interfaces;

namespace Task1
{
    public class ConsoleController
    {
        private const int DEFAULT_COMMANDLINE_ARGS_COUNT = 2;
        private readonly IBoardView _boardView;
        private readonly string[] _args;

        public void Run()
        {
            switch (_args.Length)
            {
                case DEFAULT_COMMANDLINE_ARGS_COUNT:
                {
                    int height = 0;
                    int width = 0;

                    try
                    {
                        height = int.Parse(_args[0]);
                        width = int.Parse(_args[1]);

                        if (height < 0 || width < 0)
                            throw new ArgumentOutOfRangeException("Height and width must be positive" );
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

                    var board = new ChessBoard(height, width);
                    board.Build();

                    var view = new ChessBoardView(board);
                    view.Display();
                    break;
                }
                default:
                {
                    DisplayInstruction();
                    break;
                }
            }

        }
        
        private void DisplayInstruction()
        {
            StringBuilder helpMessage = new StringBuilder();
            helpMessage.AppendLine()
                .AppendLine("Usages for program (Print chessboard)")
                .AppendLine("Input arguments: <height> <width>")
                .AppendLine("```````````")
                .AppendLine("Arguments")
                .AppendLine("```````````")
                .AppendLine("height -> The height of the chessboard to print")
                .AppendLine(" width -> The width of the chessboard to print")
                .AppendLine("```````````");
            Console.WriteLine(helpMessage);
        }

        public ConsoleController(string[] args = null)
        {
            _args = args ?? new string[] { };
        }
    }
}