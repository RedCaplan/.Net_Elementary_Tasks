using System.Collections.Generic;

namespace Task5.Models
{
    public class TranslationLanguageEN : ITranslationLanguage
    {
        private static Dictionary<int, string> _hundreds = new Dictionary<int, string>
        {
            {0,"" },
            {1,"one hundred " },
            {2,"two hundred " },
            {3,"three hundred " },
            {4,"four hundred " },
            {5,"five hundred " },
            {6,"six hundred " },
            {7,"seven hundred " },
            {8,"eight hundred " },
            {9,"nine hundred" },
        };
        private static Dictionary<int, string> _tens = new Dictionary<int, string>
        {
            {0,"" },
            {1,"" },
            {2,"twenty " },
            {3,"thirty " },
            {4,"fourty " },
            {5,"fifty " },
            {6,"sixty " },
            {7,"seventy " },
            {8,"eighty " },
            {9,"ninety " },
        };
        private static Dictionary<int, string> _units = new Dictionary<int, string>
        {
            {0,"" },
            {1,"one " },
            {2,"two " },
            {3,"three " },
            {4,"four " },
            {5,"five " },
            {6,"six " },
            {7,"seven " },
            {8,"eight " },
            {9,"nine " },
            {10,"ten " },
            {11,"eleven " },
            {12,"twelve " },
            {13,"thirteen " },
            {14,"fourteen" },
            {15,"fifteen " },
            {16,"sixteen " },
            {17,"seventeen " },
            {18,"eighteen " },
            {19,"nineteen " },
        };
        private static Dictionary<int, string> _ranks = new Dictionary<int, string>
        {
            {0,"" },
            {1,"thousand " },
            {2,"million " },
            {3,"milliard " },
        };

        public string GetHundreds(int hundred)
        {
            return _hundreds[hundred];
        }

        public string GetRanks(int rank)
        {
            return _ranks[rank];
        }

        public string GetTens(int tens)
        {
            return _tens[tens];
        }

        public string GetUnits(int unit)
        {
            return _units[unit];
        }
    }
}
