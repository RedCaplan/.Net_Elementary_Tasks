using System;
using System.Collections.Generic;
using Task3.Models;

namespace Task3
{
    public class TriangleView
    {
        private const string MESSAGE_HELP = @"Usages for program|Input arguments: <name>, <sideA>, <sideB>, <sideC>";
        private const string MESSAGE_TRIANGLE_ADD = @"Add triangle: <name>, <sideA>, <sideB>, <sideC>";
        private const string MESSAGE_CONTINUE_ADDING = @"Add new triangle? y/yes -> continue  | any other -> print";
        private const int DEFAULT_COMMANDLINE_ARGS_COUNT = 4;

        public void Display(string message = "")
        {
            Console.WriteLine(message);
        }

        public void DisplayInstruction()
        {
            Console.WriteLine(MESSAGE_HELP);
        }

        public void DisplayContinue()
        {
            Console.WriteLine();
            Console.WriteLine(MESSAGE_CONTINUE_ADDING);
        }

        public void DisplayTriangles(IReadOnlyCollection<Triangle> triangles)
        {
            Console.WriteLine("============= Triangles list: ===============");

            int index = 1;
            foreach (var triangle in triangles)
            {
                Console.WriteLine("{0}. [Triangle {1}]: {2:N2} сm", index++, triangle.Name, triangle.Area);
            }
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public TriangleDTO RequestTriangle()
        {
            Console.WriteLine(MESSAGE_TRIANGLE_ADD);
            string[] arguments = Console.ReadLine()?.Split(',');

            if (arguments?.Length != DEFAULT_COMMANDLINE_ARGS_COUNT)
            {
                throw new ArgumentOutOfRangeException("argument line", "Must be 4 arguments");
            }

            string name = arguments[0];
            double sideA = double.Parse(arguments[1]);
            double sideB = double.Parse(arguments[2]);
            double sideC = double.Parse(arguments[3]);

            return new TriangleDTO(sideA,sideB,sideC,name);
        }
    }
}
