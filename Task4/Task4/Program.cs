using Serilog;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.File("log.txt")
               .CreateLogger();

            FileParserController fileParserController = new FileParserController();
            fileParserController.Run();
        }
    }
}
