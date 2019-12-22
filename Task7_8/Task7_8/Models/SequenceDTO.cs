using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7_8.Models.Enums;

namespace Task7_8.Models
{
    public struct SequenceDTO
    {
        public SequenceType SequenceType { get;}
        public int MinRange { get; }
        public int MaxRange { get; }

        public SequenceDTO(SequenceType sequenceType, int minRange, int maxRange)
        {
            SequenceType = sequenceType;
            MinRange = minRange;
            MaxRange = maxRange;
        }
    }
}
