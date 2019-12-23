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

            Log.Information("New start with args: {args}", args);
            TicketView ticketView = new TicketView();
            TicketController ticketController = new TicketController(ticketView);
            ticketController.Run();
        }
    }
}
