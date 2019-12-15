using System;

namespace Task6
{
    public class TicketView
    {
        private const string MESSAGE_HELP = @"Usages for program|Input arguments: <filepath>, |(optional) <minrange>, <maxrange>|";

        public TicketView()
        {
        }

        public void Display(string message = "")
        {
            Console.WriteLine(message);
        }

        public void DisplayInstruction()
        {
            Console.WriteLine(MESSAGE_HELP);
        }
    }
}
