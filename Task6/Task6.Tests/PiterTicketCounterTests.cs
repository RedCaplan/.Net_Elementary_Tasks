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

        [Fact]
        public void TestPiterTicketLuckyCountCorrect()
        {
            int minRange = 0;
            int maxRange = 999999;
            TicketGenerator ticketGenerator = TicketGenerator.Build(minRange, maxRange);
            TicketCounter ticketCounter = new PiterTicketCounter(ticketGenerator);
            int expectedAmount = 55252;

            int amount = ticketCounter.CountLuckyTickets();

            Assert.Equal(expectedAmount, amount);
        }
    }
}
