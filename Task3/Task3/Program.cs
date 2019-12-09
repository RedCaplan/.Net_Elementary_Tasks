using Serilog;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("log.txt")
                .CreateLogger();

            TriangleController triangleController = new TriangleController(args);
            triangleController.Run();
        }
    }
}
