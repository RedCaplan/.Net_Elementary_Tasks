namespace Task3.Models
{
    public class TriangleDTO
    {
        public TriangleDTO(double sideA, double sideB, double sideC, string name = "")
        {
            Name = name;
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public string Name { get; }

        public double SideA { get; }

        public double SideB { get; }

        public double SideC { get; }
    }
}
