namespace Task1.Models.Interfaces
{
    public interface IBoard
    {
        BoardSize BoardSize { get;
        }
        ICell this[int height, int width] { get; }

        void Build();
    }
}