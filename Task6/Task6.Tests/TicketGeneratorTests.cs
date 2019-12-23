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

        [Theory]
        [InlineData(0,10,11)]
        [InlineData(100, 500, 401)]
        [InlineData(0, 999999, 1000000)]
        public void GeneratorMakesTheCorrectAmountOfTickets(int minRange, int maxRange, int ticketsAmount)
        {
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
