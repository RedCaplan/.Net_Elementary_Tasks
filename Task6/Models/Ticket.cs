namespace Task6.Models
{
    public class Ticket
    {
        private readonly int _number;

        public Ticket(int number)
        {
            _number = number;
        }

        public int Number => _number;
    }
}
