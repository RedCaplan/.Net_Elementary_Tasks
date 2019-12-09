using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Task2.Models;

namespace Task2
{
    public class EnvelopeController
    {
        private const int DEFAULT_COMMANDLINE_ARGS_COUNT = 0;

        private static readonly string[] CONTINUE_KEY = { "y", "yes" };
        private readonly EnvelopeView _envelopeView;
        private readonly string[] _args;

        public EnvelopeController(EnvelopeView envelopeView, string[] args)
        {
            _args = args ?? new string[] { };
            _envelopeView = envelopeView;
        }
        public EnvelopeController(string[] args = null) : this(new EnvelopeView(), args)
        {
        }

        public void Run()
        {

            if (_args.Length != DEFAULT_COMMANDLINE_ARGS_COUNT)
            {
                _envelopeView.DisplayInstruction();

                return;
            }

            string message = "";
            bool isActive = true;
            while (isActive)
            {
                try
                {
                    Log.Information("Getting envelopes");
                    Envelope envelopeFirst = GetInputEnvelope("first");
                    Envelope envelopeSecond = GetInputEnvelope("second");

                    if (envelopeFirst.CompareTo(envelopeSecond) > 0)
                    {
                        message = " In the first envelope you can put the second";
                    }
                    else if (envelopeSecond.CompareTo(envelopeFirst) > 0)
                    {
                        message = " In the second envelope you can put the first";
                    }
                    else
                    {
                        message = " Can`t put one envelope in another";
                    }
                }
                catch (Exception ex) when (ex is FormatException
                                       || ex is ArgumentOutOfRangeException
                                       || ex is OverflowException)
                {
                    message = ex.Message;
                    Log.Error(ex, "Exception thrown");
                }

                _envelopeView.Display(message);
                _envelopeView.DisplayReset();

                string userInput = _envelopeView.GetInput()?.ToLower();
                isActive = CONTINUE_KEY.Contains(userInput);
            }
        }

        private Envelope GetInputEnvelope(string envelopeName = "")
        {
            EnvelopeSize envelopeSize = _envelopeView.RequestEnvelopeSize(envelopeName);

            Log.Information("Envelope sizes entered: {height} {width}",
                envelopeSize.Height, envelopeSize.Width);

            if (envelopeSize.Height < 0)
                throw new ArgumentOutOfRangeException("Height");

            if (envelopeSize.Width < 0)
                throw new ArgumentOutOfRangeException("Width");

            return new Envelope(envelopeSize); ;
        }
    }
}
