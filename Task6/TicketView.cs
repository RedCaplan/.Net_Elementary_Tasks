using System;
using Task6.Models.Constants;

namespace Task6
{
    public class TicketView
    {
        public TicketView()
        {
        }

        public void Display(string message = "")
        {
            Console.WriteLine(message);
        }

        public void DisplayInstruction()
        {
            Console.WriteLine(Messages.MESSAGE_HELP);
        }
    }
}
