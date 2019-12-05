using Serilog;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("log.txt")
                .CreateLogger();

            ChessBoardController consoleController = new ChessBoardController(args);
            consoleController.Run();
        }

    }
}