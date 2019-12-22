using Serilog;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.File("log.txt")
               .CreateLogger();

            ConverterController converterController = new ConverterController();
            converterController.Run();
        }
    }
}
