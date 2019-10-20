namespace p02.PerfectNum
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var mersenneIndexes = new int[] { 2, 3, 5, 7, 13, 17, 19, 31, 61, 89, 107, 127, 521 };
            var number = new int[20_000];

            for (int i = 0; i < mersenneIndexes.Length; i++)
            {
                FindPerfectNumber(i, mersenneIndexes[i], number);
                Array.Clear(number, 0, number.Length);
            }
        }

        private static void FindPerfectNumber(int currentIndex, int mersenneIndex, int[] number)
        {
            //(2^n) - 1
            var currentDigits = 1;
            number[0] = 1;
            //mersenneNumber == n
            for (int i = 0; i < mersenneIndex; i++)
            {
                IncreaseByDoublingNumber(ref currentDigits, number);
            }
            number[0]--;

            //2^(n -1)
            for (int i = 0; i < mersenneIndex - 1; i++)
            {
                IncreaseByDoublingNumber(ref currentDigits, number);
            }

            Console.Write($"{currentIndex + 1}-то съвършено число е = ");
            Print(currentDigits, number);
        }

        private static void IncreaseByDoublingNumber(ref int currentDigits, int[] number)
        {
            int temp, remainder = 0;
            for (int i = 0; i < currentDigits; i++)
            {
                temp = number[i] * 2 + remainder;
                number[i] = temp % 10;
                remainder = temp / 10;
            }

            if (remainder > 0)
            {
                number[currentDigits++] = remainder;
            }
        }

        private static void Print(int currentDigits, int[] number)
        {
            for (int i = currentDigits; i > 0; i--)
            {
                Console.Write($"{number[i - 1]}");
            }
            Console.WriteLine();
        }
    }
}
