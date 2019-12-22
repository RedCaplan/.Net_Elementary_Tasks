using Serilog;
using System;
using Task5.Models;

namespace Task5
{
    public class ConverterController
    {
        private const int DEFAULT_COMMANDLINE_ARGS_COUNT = 1;
        private readonly ConverterView _converterView;
        public ConverterController(ConverterView converterView)
        {
            _converterView = converterView;
        }
        public ConverterController(string[] args = null) : this(new ConverterView())
        {
        }

        public void Run()
        {
         
            try
            {
                IntToTextConverter converter = new IntToTextConverter(new TranslationLanguageEN());
                int number = _converterView.GetNumber();
                Log.Information("New start with number: {number}", number);

                string message = converter.ConvertToText(number);

                Log.Information("ConvertResult: {number}, {numberText}",
                    number, message);

                _converterView.Display(message);
            }
            catch (FormatException ex)
            {
                _converterView.DisplayInstruction();
                Log.Error(ex, "Exception thrown");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _converterView.DisplayInstruction();
                Log.Error(ex, "Exception thrown");
            }
            catch (OverflowException ex)
            {
                _converterView.DisplayInstruction();
                Log.Error(ex, "Exception thrown");
            }
        }

    }
}
