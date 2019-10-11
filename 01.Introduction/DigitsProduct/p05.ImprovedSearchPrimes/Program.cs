namespace p05.ImprovedSearchPrimes
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class Program
    {
        //00:00:00.0055446 -- mine
        //00:00:00.0064490 -- Improved
        //V2 -- non relevant
        public static void Main()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var input = 200;
            var primes = new int[30_000];
            var pN = 0;
            FindPrimes(input, primes, pN);
            primes = primes.TakeWhile(x => x != default(int)).ToArray();
            Console.Write("\n");

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
        }

        public static bool IsPrime(int i,int[] primes, int pN)
        {
            var index = 0;
            while (index < pN && primes[index] * primes[index] <= i)
            {
                if (i % primes[index] == 0)
                {
                    return false;
                }
                index++;
            }

            return true;
        }

        public static void FindPrimes(int number, int[] primes, int pN)
        {
            var i = 2;
            while (i < number)
            {
                if (IsPrime(i, primes, pN))
                {
                    primes[pN] = i;
                    pN++;
                    Console.Write($"{i} ");
                }
                i++;
            }
        }
    }
}
