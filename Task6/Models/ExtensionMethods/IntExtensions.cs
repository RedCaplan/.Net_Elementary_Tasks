using System;

namespace Task6.Models.ExtensionMethods
{
    public static class IntExtensions
    {
        public static int DigitArrayLength(this int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return 1 + (int)Math.Log10(number);
        }

        public static int[] ToArray(this int number)
        {
            return number.ToArray(number.DigitArrayLength());
        }

        public static int[] ToArray(this int number, int capacity)
        {
            int size = number.DigitArrayLength();

            int[] array = new int[capacity];
            for (int index = 0; index < size; index++)
            {
                array[index] = number % 10;
                number /= 10;
            }

            return array;
        }
    }
}
