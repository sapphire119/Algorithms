namespace p04.PerfectNumber
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            var mPrimes = new int[] { 2, 3, 5, 7, 13, 17, 19, 31, 61, 89 };
            var number = new int[200];

            for (int i = 1; i <= mPrimes.Length; i++)
            {
                Solve(i, mPrimes[i - 1], number);
                Array.Clear(number, 0, number.Length);
            }
        }

        private static void Solve(int currentPosition, int mersennePrime, int[] number)
        {
            var pN = 1;
            number[0] = 1;
            //(2^n) - 1
            for (int i = 0; i < mersennePrime; i++)
            {
                IncreaseByDoubling(ref pN, number);
            }
            number[0]--;


            //2 ^( n -1 )
            for (int i = 0; i < mersennePrime - 1; i++)
            {
                IncreaseByDoubling(ref pN, number);
            }

            Console.WriteLine("The {0} perfect number is = {1}", currentPosition, GetNumber(pN, number));
        }

        private static string GetNumber(int pN, int[] number)
        {
            var result = "";
            for (int i = pN -1; i >= 0; i--)
            {
                result = string.Concat(result, number[i]);
            }

            return result;
        }
        
        private static void IncreaseByDoubling(ref int pN, int[] number)
        {
            var temp = 0;
            var remainder = 0;

            for (int i = 0; i < pN; i++)
            {
                temp = 2 * number[i] + remainder;
                number[i] = temp % 10;
                remainder = temp / 10;
            }

            if (remainder > 0)
            {
                number[pN++] = remainder;
            }
        }
    }
}
