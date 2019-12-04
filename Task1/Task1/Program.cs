namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ChessBoardController consoleController = new ChessBoardController(args);
            consoleController.Run();
        }
    }
}