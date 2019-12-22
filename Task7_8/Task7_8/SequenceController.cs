using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Task7_8.Models;
using Task7_8.Models.Enums;

namespace Task7_8
{
    public class SequenceController
    {
        private readonly SequenceView _sequenceView;

        public SequenceController(SequenceView ticketView)
        {
            _sequenceView = ticketView;
        }
        public SequenceController(string[] args = null) : this(new SequenceView())
        {
        }

        public void Run()
        {
            try
            {
                ISequence sequence = CreateSequence();
                _sequenceView.DisplaySequence(sequence);
            }
            catch (Exception ex) when (ex is FormatException
                                       || ex is ArgumentOutOfRangeException
                                       || ex is OverflowException
                                       || ex is FileNotFoundException)
            {
                _sequenceView.DisplayInstruction();
                Log.Error(ex, "Exception thrown");
            }
        }

        private ISequence CreateSequence()
        {
            SequenceDTO sequenceDTO = _sequenceView.GetSequence();

            Log.Information("Getted sequence: {sequenceType}, {minRange}, {maxRange}",
                sequenceDTO.SequenceType, sequenceDTO.MinRange, sequenceDTO.MaxRange);

            ValidateSequenceDTO(sequenceDTO);

            ISequence sequence;
            switch (sequenceDTO.SequenceType)
            {
                case SequenceType.Fibonacci:
                {
                   sequence = new FibonacciSequence(sequenceDTO);
                   break;
                }
                case SequenceType.SquareLess:
                {
                    sequence = new SquareLessSequence(sequenceDTO);
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException(sequenceDTO.SequenceType.ToString(),
                        "No such mode of sequence");
                }
            }

            return sequence;
        }

        private void ValidateSequenceDTO(SequenceDTO sequence)
        {
            if (sequence.MinRange < 0)
            {
                throw new ArgumentOutOfRangeException("minRange", "Must be positive");
            }
            if (sequence.MaxRange < 0)
            {
                throw new ArgumentOutOfRangeException("maxRange", "Must be positive");
            }

            if (sequence.MinRange > sequence.MaxRange)
            {
                throw new ArgumentOutOfRangeException("range", "The Minimum range must be greater than or equal to the maximum");
            }
        }
    }
}
