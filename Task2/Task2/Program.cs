using Serilog;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("log.txt")
                .CreateLogger();

            EnvelopeController envelopeController = new EnvelopeController(args);
            envelopeController.Run();
        }
    }
}
