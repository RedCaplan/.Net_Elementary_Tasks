using Task6.Models;
using Task6.Models.ExtensionMethods;
using Xunit;

namespace Task6.Tests
{
    public class MoscowTicketCounterTests
    {
        [Theory]
        [InlineData(100001, true)]
        [InlineData(412567, false)]
        [InlineData(889991, false)]
        [InlineData(11, true)]
        [InlineData(100100, true)]
        [InlineData(500000, false)]
        public void TestMoscowTicketLucky(int ticketNumber, bool isLucky)
        {
            Ticket ticket = new Ticket(ticketNumber);
            bool result;
            TicketCounter ticketCounter = new MoscowTicketCounter(TicketGenerator.Build(0, ticketNumber));

            result = ticketCounter.IsLucky(ticket);

            Assert.Equal(result, isLucky);
        }

        [Fact]
        public void TestMoscowTicketLuckyCountCorrect()
        {
            int minRange = 0;
            int maxRange = 999999;
            TicketGenerator ticketGenerator = TicketGenerator.Build(minRange, maxRange);
            TicketCounter ticketCounter = new MoscowTicketCounter(ticketGenerator);
            int expectedAmount = 55252;

            int amount = ticketCounter.CountLuckyTickets();

            Assert.Equal(expectedAmount, amount);
        }


    }
}
