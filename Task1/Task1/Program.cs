namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConsoleController consoleController = new ConsoleController(args);
            consoleController.Run();
        }
    }
}