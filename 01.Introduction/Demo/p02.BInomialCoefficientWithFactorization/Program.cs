namespace p02.BInomialCoefficientWithFactorization
{
    using System;

    public class Program
    {
        //private static int[] primes = new int[200], count = new int[200];
        //private static int pN;

        public static void Main()
        {
            var n = 9;
            var k = 5;
            var pN = 0;
            var primes = new int[200];
            var count = new int[200];

            Console.Write("C({0}, {1}) = ", n, k);

            Solve(n - k + 1, n, 1, primes, count, ref pN);
            Solve(1, k, -1, primes, count, ref pN);

            Console.Write("{0}\n", Calc(primes, count, pN));
        }

        private static void Solve(int start, int end, int incrementerSign, int[] primes, int[] count, ref int pN)
        {
            for (int i = start; i <= end; i++)
            {
                var mul = i;
                var prime = 2;
                while (mul != 1)
                {
                    int power;
                    for (power = 0; mul % prime == 0; mul /= prime, power++) ;
                    if (power > 0)
                    {
                        Modify(prime, incrementerSign * power, primes, count, ref pN);
                    }
                    prime++;
                }
            }
        }

        private static void Modify(int prime, int powerWithSign, int[] primes, int[] count, ref int pN)
        {
            for (int i = 0; i < pN; i++)
            {
                if (primes[i] == prime)
                {
                    count[i] += powerWithSign;
                    return;
                }
            }
            count[pN] += powerWithSign;
            primes[pN++] = prime;
        }

        private static int Calc(int[] primes, int[] count, int pN)
        {
            var result = 1;

            for (int i = 0; i < pN; i++)
            {
                for (int j = 0; j < count[i]; j++)
                {
                    result *= primes[i];
                }
            }
            return result;
        }
    }
}
