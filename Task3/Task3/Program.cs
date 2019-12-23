using Serilog;

namespace Task3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("log.txt")
                .CreateLogger();

            TriangleView triangleView = new TriangleView();
            TriangleController triangleController = new TriangleController(triangleView);
            triangleController.Run();
        }
    }
}
