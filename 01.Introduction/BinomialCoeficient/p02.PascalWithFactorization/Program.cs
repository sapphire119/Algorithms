namespace p02.PascalWithFactorization
{
    using System;

    public class Program
    {
        private static int n = 12, k = 3;
        private static int numberOfElements;
        private static int[] primes = new int[200], countPowerOfNumber = new int[200];

        public static void Main()
        {
            Console.Write("C({0}, {1}) = ", n, k);
            numberOfElements = 0;
            if (n - k < k) k = n - k;

            Solve(n - k + 1, n, 1);
            Solve(1, k, -1);
            Console.Write("{0}\n", CalculatedFactorResult());
        }

        private static void Solve(int start, int end, int incrementerSign)
        {
            int prime, mul, countPower, i;
            for (i = start; i <= end; i++)
            {
                mul = i;
                prime = 2;
                while (mul != 1)
                {
                    for (countPower = 0; mul % prime == 0; mul /= prime, countPower++) ;
                    if (countPower > 0)
                    {
                        Modify(prime, incrementerSign * countPower);
                    }
                    prime++;
                }
            }
        }

        private static void Modify(int number, int powerOfNumber)
        {
            int i;
            for (i = 0; i < numberOfElements; i++)
            {
                if (number == primes[i])
                {
                    countPowerOfNumber[i] += powerOfNumber;
                    return;
                }
            }

            countPowerOfNumber[numberOfElements] = powerOfNumber;
            primes[numberOfElements++] = number;
        }

        private static int CalculatedFactorResult()
        {
            int i, j, result = 1;
            for (i = 0; i < numberOfElements; i++)
            {
                for (j = 0; j < countPowerOfNumber[i]; j++)
                {
                    result *= primes[i];
                }
            }

            return result;
        }
    }
}