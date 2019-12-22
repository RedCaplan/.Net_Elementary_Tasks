using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_8.Models
{
    public interface ISequence : IEnumerable<int>
    {
        int MinRange { get; }

        int MaxRange { get; }
    }
}
