namespace p01.Index
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = 1_000;

            var nums = Enumerable.Range(2, input).ToList();

            var primes = SieveEratosthenes(nums);

            var result = GetPrimes(primes, nums);

            PrintOutput(result);
        }

        private static List<int> SieveEratosthenes(List<int> nums)
        {
            var primes = new List<int>(nums);

            return primes;
        }

        private static List<string> GetPrimes(List<int> primes, List<int> nums)
        {
            var result = new List<string>();
            for (int i = 1; i < nums.Count; i++)
            {
                var currentNumber = nums[i];
                if (currentNumber % 2 == 0)
                {
                    for (int pi = 0; pi < primes.Count; pi++)
                    {
                        for (int pj = 0; pj < primes.Count; pj++)
                        {
                            var firstPrime = primes[pi];
                            var secondPrime = primes[pj];

                            if (currentNumber == (firstPrime + secondPrime))
                            {
                                result.Add($"{currentNumber} = {firstPrime} + {secondPrime}");
                            }
                        }
                    }
                }
            }


            return result;
        }

        private static void PrintOutput(List<string> result)
        {
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
