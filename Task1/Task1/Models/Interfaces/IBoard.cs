namespace Task1.Models.Interfaces
{
    interface IBoard
    {
        int Height { get; }
        int Width { get; }
       
        ICell this[int height, int width] { get; }

        void Build();
    }
}