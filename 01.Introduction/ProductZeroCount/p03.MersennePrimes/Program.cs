namespace p03.MersennePrimes
{
    using System;
    
    using System.Collections.Generic;
    using System.Numerics;

    public class Program
    {
        public static void Main()
        {
            var input = 20L;

            var primes = GetPrimes(input);
            for (int p = 0; p < primes.Length; p++)
            {
                var mersenneNum = 2097151;/*(BigInteger)Math.Pow(2, primes[p]) - 1;*/
                if (IsPrime(mersenneNum))
                {
                    Console.WriteLine($@"The number {mersenneNum} is a Mersenne Prime of p={primes[p]}");
                }
            }
        }

        private static bool IsPrime(BigInteger num, bool primeCheck = true, bool compsoiteCheck = false)
        {
            var i = 2;
            while (i <= Math.Pow(Math.E, BigInteger.Log(num) / 2) && i * i <= num)
            {
                if (num % i == 0)
                {
                    //Reverse to "true" for 2p-1 to see if non-prime
                    return compsoiteCheck;
                }
                i++;
            }
            //Reverse to "false" for 2p-1 to see if non-prime
            return primeCheck;
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
