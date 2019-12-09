using System;
using System.Collections.Generic;

namespace Task2.Models
{
    public class EnvelopeView
    {
        private const string MESSAGE_HELP = @"Usages for program|Input arguments: <height> <width>";
        private const string MESSAGE_RESET = @"Reset envelopes? y/yes -> continue  | any other -> exit";

        public EnvelopeView()
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

        public void DisplayReset()
        {
            Console.WriteLine(MESSAGE_RESET);
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public EnvelopeSize RequestEnvelopeSize(string envelopeName = "")
        {
            Console.WriteLine("Enter {0} envelope: ", envelopeName);

            Console.Write("Input the size of the first side:  ");
            double height = double.Parse(Console.ReadLine());

            Console.Write("Input the size of the second side: ");
            double width = double.Parse(Console.ReadLine());

            return new EnvelopeSize(height,width);

        }

    }
}
