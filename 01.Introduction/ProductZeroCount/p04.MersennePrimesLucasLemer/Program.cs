namespace p04.MersennePrimesLucasLemer
{
    using System;
    using System.Numerics;

    public class Program
    {
        public static void Main()
        {
            var input = 25L;

            var primes = GetPrimes(input);

            for (int p = 0; p < primes.Length; p++)
            {
                var mersenneNum = (BigInteger)Math.Pow(2, primes[p]) - 1;
                if (p == 2 || IsMersennePrime(mersenneNum, primes[p]))
                {
                    Console.WriteLine($@"The number {mersenneNum} is a Mersenne Prime of p={primes[p]}");
                }
            }
        }

        private static bool IsMersennePrime(BigInteger num, int primeFactor)
        {
            ulong lucasStart = 4L;
            BigInteger lucasRemainder = lucasStart % num;
            var count = primeFactor - 1;
            for (int i = 0; i < count - 1; i++)
            {
                lucasRemainder = ((lucasRemainder * lucasRemainder) - 2) % num;
            }
            return lucasRemainder == 0;
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
