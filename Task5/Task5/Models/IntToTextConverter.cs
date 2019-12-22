using System;
using System.Linq;
using System.Text;
using Task5.Models.ExtensionMethods;

namespace Task5.Models
{
    public class IntToTextConverter
    {
        private ITranslationLanguage _languageTranslator;
        public IntToTextConverter(ITranslationLanguage language)
        {
            _languageTranslator = language;
        }

        public string ConvertToText(int number)
        {
            int ranks = (int)Math.Ceiling(number.DigitArrayLength() / 3.0);
            int[] digits = number.ToArray(ranks * 3, ranks * 3 - number.DigitArrayLength());

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < ranks; i++)
            {
                result.Append(ToWord(digits[i * 3], digits[i * 3 + 1], digits[i * 3 + 2], ranks - i - 1));
            }

            return result.ToString();
        }

        private string ToWord(int hundreds, int tens, int units, int rank)
        {
            StringBuilder result = new StringBuilder();
            result.Append(_languageTranslator.GetHundreds(hundreds));
            if (tens == 1)
            {
                result.Append(_languageTranslator.GetUnits(units + 10));
            }
            else
            {
                result.Append(_languageTranslator.GetTens(tens));
                result.Append(_languageTranslator.GetUnits(units));
            }
            result.Append(_languageTranslator.GetRanks(rank));
            return result.ToString();
        }
    }
}
