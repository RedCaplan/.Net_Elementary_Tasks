using System;

namespace Task3.Models
{
    public class Triangle : IComparable<Triangle>
    {
        private readonly string _name;
        private readonly TriangleSides _sides;
        private readonly double _area;
        private readonly double _perimeter;

        private Triangle(TriangleSides triangleSides, string name = "")
        {
            _sides = triangleSides;
            _name = name;
            _perimeter = CalculatePerimeter();
            _area = CalculateArea();
        }

        public string Name
        {
            get => _name;
        }

        public TriangleSides Sides
        {
            get => _sides;
        }

        public double Area
        {
            get => _area;
        }

        public double Perimeter
        {
            get => _perimeter;
        }

        public static Triangle Build(TriangleSides triangleSides, string name = "")
        {
            if (triangleSides.SideA + triangleSides.SideB > triangleSides.SideC
             && triangleSides.SideA + triangleSides.SideC > triangleSides.SideB
             && triangleSides.SideB + triangleSides.SideC > triangleSides.SideA)
            {
                return new Triangle(triangleSides, name);
            }
            else
            {
                throw new ArgumentOutOfRangeException("triangleSides", "Can't build a triangle with given sides");
            }
        }

        public int CompareTo(Triangle other)
        {
            if (Area > other.Area)
            {

                return -1;
            }
            else if (Area < other.Area)
            {

                return 1;
            }
            else
            {

                return 0;
            }
        }

        private double CalculateArea()
        {
            double halpPerimeter = _perimeter / 2;

            double area = Math.Sqrt(halpPerimeter 
                                    * (halpPerimeter - _sides.SideA)
                                    * (halpPerimeter - _sides.SideB) 
                                    * (halpPerimeter - _sides.SideC));

            return area; 
        }

        private double CalculatePerimeter()
        {
            return _sides.SideA + _sides.SideB + _sides.SideC;
        }
    }
}
