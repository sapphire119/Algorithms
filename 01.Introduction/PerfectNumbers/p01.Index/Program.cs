namespace p01.Index
{
    using System;
    using System.Text;

    public class Program
    {
        private static readonly int[] mPrimes = { 2, 3, 5, 7, 13, 17, 19, 31, 61, 89 };
        private static int k;
        private static int[] number = new int[200];

        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 1; i <= mPrimes.Length; i++)
            {
                Perfect(i, mPrimes[i - 1]);
            }
        }

        private static void Perfect(int index, int mersennePrime)
        {
            //(2 ^ n) - 1
            k = 1;
            number[0] = 1;
            for (int i = 0; i < mersennePrime; i++)
            {
                DoubleN();
            }

            number[0]--;
            //2^(n-1)
            //2 ^ (n - 1); n == MersennePrime
            for (int i = 0; i < mersennePrime - 1; i++)
            {
                DoubleN();
            }

            Console.Write($"{index}-то съвършено число е = ");
            Print();
        }

        private static void DoubleN()
        {
            int carry = 0, temp;
            for (int i = 0; i < k; i++)
            {
                temp = number[i] * 2 + carry;
                number[i] = temp % 10;
                carry = temp / 10;
            }

            if (carry > 0)
            {
                number[k++] = carry;
            }
        }

        private static void Print()
        {
            for (int i = k; i > 0; i--)
            {
                Console.Write($"{number[i - 1]}");
            }
            Console.WriteLine();
        }
    }
}
