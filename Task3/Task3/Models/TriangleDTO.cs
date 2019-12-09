namespace Task3.Models
{
    public class TriangleDTO
    {
        public TriangleDTO(string name, TriangleSides sides)
        {
            Name = name;
            Sides = sides;
        }

        public string Name { get; }
        public TriangleSides Sides { get; }
    }
}
