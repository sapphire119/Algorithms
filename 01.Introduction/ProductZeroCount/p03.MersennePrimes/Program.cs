namespace p03.MersennePrimes
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = 20L;

            var primes = GetPrimes(input);

            for (int p = 0; p < primes.Length; p++)
            {
                var mersenneNum = (long)Math.Pow(2, primes[p]) - 1;
                if (IsPrime(mersenneNum))
                {
                    Console.WriteLine($@"The number {mersenneNum} is a Mersenne Prime of p={primes[p]}");
                }
            }
        }

        private static bool IsPrime(long num)
        {
            var i = 2;
            while (i <= Math.Sqrt(num) && i * i <= num)
            {
                if (num % i == 0)
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        private static int[] GetPrimes(long input)
        {
            var startEle = 2;
            var arr = new int[input];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = SetPrime(startEle);
                startEle = arr[i] + 1;
            }

            return arr;
        }

        private static int SetPrime(int element)
        {
            while (!IsPrime(element)) element++;
            return element;
        }
    }
}
