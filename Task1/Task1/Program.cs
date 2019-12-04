namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ChessBoardController chessBoardController = new ChessBoardController(args);
            chessBoardController.Run();
        }
    }
}