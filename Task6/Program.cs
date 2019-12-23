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

            TicketView ticketView = new TicketView();
            TicketController ticketController = new TicketController(ticketView, args);
            ticketController.Run();
        }
    }
}
