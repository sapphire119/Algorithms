namespace p02.SieveOfEratosten
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var input = 200;

            SieveOfEratosten(input);

            stopWatch.Stop();

            Console.WriteLine(stopWatch.Elapsed);
            //var n = 2000;

        }

        private static void SieveOfEratosten(int limit)
        {
            var arr = Enumerable.Range(2, limit - 1).ToList();

            var primes = GetPrimes(arr);

            Console.WriteLine(string.Join(" ", primes));
        }

        public static List<int> GetPrimes(List<int> numbers)
        {
            var primes = new List<int>(numbers);

            for (int i = 0; i < primes.Count; i++)
            {
                for (int j = i + 1; j < primes.Count; j++)
                {
                    if (primes[j] % primes[i] == 0)
                    {
                        primes.RemoveAt(j);
                    }
                }
            }

            return primes;
        }
    }
}
