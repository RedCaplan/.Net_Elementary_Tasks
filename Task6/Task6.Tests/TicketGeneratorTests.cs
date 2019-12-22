using System;
using Task6.Models;
using Xunit;

namespace Task6.Tests
{
    public class TicketGeneratorTests
    {
        [Theory]
        [InlineData(-5, 10)]
        [InlineData(-5, -3)]
        [InlineData(-5, -10)]
        [InlineData(10, 0)]
        [InlineData(0, -1)]
        [InlineData(0,0)]
        public void BuildGeneratorWithWrongRangeThrowsException(int minRange, int maxRange)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                ()=>TicketGenerator.Build(minRange, maxRange));
        }

        [Fact]
        public void GeneratorMakesTheCorrectAmountOfTickets()
        {
            int minRange = 1;
            int maxRange = 10;
            int ticketsAmount = maxRange - minRange + 1;
            TicketGenerator ticketGenerator = TicketGenerator.Build(minRange, maxRange);
            int count = 0;

            foreach(var item in ticketGenerator)
            {
                count++;
            }

            Assert.Equal(ticketsAmount, count);
        }
    }
}
