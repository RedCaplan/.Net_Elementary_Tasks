using System.Collections.Generic;

namespace Task7_8.Models
{
    public interface ISequence : IEnumerable<int>
    {
        int MinRange { get; }

        int MaxRange { get; }
    }
}
