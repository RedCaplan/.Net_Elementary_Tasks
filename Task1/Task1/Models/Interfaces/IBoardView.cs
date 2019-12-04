namespace Task1.Models.Interfaces
{
    public interface IBoardView
    {
        IBoard Board { get; set; }

        void Display();
        void DisplayInstruction();
    }
}