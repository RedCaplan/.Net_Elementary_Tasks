using System;

namespace Task3.Models
{
    public class Triangle : IComparable<Triangle>
    {
        private readonly double _area;
        private readonly double _perimeter;

        private Triangle(double sideA, double sideB, double sideC, string name = "")
        {
            Name = name;
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            _perimeter = CalculatePerimeter();
            _area = CalculateArea();
        }

        public string Name { get; }

        public double SideA { get; }

        public double SideB { get; }

        public double SideC { get; }

        public double Area => _area;

        public double Perimeter => _perimeter;

        public static Triangle Build(double sideA, double sideB, double sideC, string name = "")
        {
            if (sideA + sideB > sideC
             && sideA + sideC > sideB
             && sideB + sideC > sideA)
            {
                return new Triangle(sideA, sideB, sideC, name);
            }
            else
            {
                throw new ArgumentOutOfRangeException("triangleSides",
                    "Can't build a triangle with given sides");
            }
        }

        public static Triangle Build(TriangleDTO triangle)
        {
            return Build(triangle.SideA, triangle.SideB, triangle.SideC, triangle.Name);
        }

        public int CompareTo(Triangle other)
        {
            if (Area > other.Area)
            {

                return -1;
            }

            if (Area < other.Area)
            {

                return 1;
            }

            return 0;
        }

        private double CalculateArea()
        {
            double halpPerimeter = _perimeter / 2;

            double area = Math.Sqrt(halpPerimeter
                                    * (halpPerimeter - SideA)
                                    * (halpPerimeter - SideB)
                                    * (halpPerimeter - SideC));

            return area;
        }

        private double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }
    }
}
