using Task6.Models;
using Xunit;

namespace Task6.Tests
{
    public class PiterTicketCounterTests
    {
        [Theory]
        [InlineData(153829, false)]
        [InlineData(399454, true)]
        [InlineData(111111, true)]
        [InlineData(100100, true)]
        [InlineData(500000, false)]
        [InlineData(228536, true)]
        public void TestPiterTicketLucky(int ticketNumber, bool isLucky)
        {
            bool result;
            Ticket ticket = new Ticket(ticketNumber);
            TicketCounter ticketCounter = new PiterTicketCounter(TicketGenerator.Build(0, 1));

            result = ticketCounter.IsLucky(ticket);

            Assert.Equal(result, isLucky);
        }
    }
}
