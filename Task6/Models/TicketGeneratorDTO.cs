namespace Task6.Models
{
    public class TicketGeneratorDTO
    {
        public TicketGeneratorDTO(int minRange, int maxRange)
        {
            MinRange = minRange;
            MaxRange = maxRange;
        }

        public int MinRange { get; }

        public int MaxRange { get; }
    }
}
