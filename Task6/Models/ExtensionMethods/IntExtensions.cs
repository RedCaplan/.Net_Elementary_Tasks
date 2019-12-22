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
            return number.ToArray(capacity, 0);
        }

        public static int[] ToArray(this int number, int capacity, int startPos)
        {
            int size = number.DigitArrayLength();

            if (capacity < startPos + size)
            {
                capacity = startPos + size;
            }

            int[] array = new int[capacity];
            for (int index = startPos + size - 1; index >= startPos; index--)
            {
                array[index] = number % 10;
                number /= 10;
            }

            return array;
        }
    }
}
