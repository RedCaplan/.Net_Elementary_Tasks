using Serilog;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("log.txt")
                .CreateLogger();

            TicketController ticketController = new TicketController(args);
            ticketController.Run();
        }
    }
}
