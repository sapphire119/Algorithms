namespace p03.ReciprocalPerfectNum
{
    using System;
    using System.Text;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int input = 10_000;

            for (int currentNumber = 1; currentNumber <= input; currentNumber++)
            {
                var divisors = new int[1000];
                if (ReciprocalEqualTo2(currentNumber, divisors))
                {
                    Print(currentNumber, divisors);
                }
            }
        }

        private static bool ReciprocalEqualTo2(int currentNumber, int[] divisors)
        {
            divisors = GetDivisors(currentNumber, divisors);

            var result = divisors.Where(x => x != 0).Sum(x => (1.0 / (double)x));
            if (result != 2.0)
            {
                return false;
            }
            return true;
        }

        private static int[] GetDivisors(int currentNumber, int[] divisors)
        {
            var startNum = 2;
            var index = 0;

            divisors[index] = 1;

            while (startNum <= Math.Sqrt(currentNumber) && startNum * startNum <= currentNumber)
            {
                if (currentNumber % startNum == 0)
                {
                    divisors[++index] = startNum;
                    divisors[++index] = currentNumber / startNum;
                }
                startNum++;
            }

            divisors[++index] = currentNumber;

            return divisors;
        }

        private static void Print(int currentNumber, int[] divisors)
        {
            var result = Array.FindAll(divisors, x => x != 0).OrderBy(x => x);
            Console.WriteLine($@"The current number {currentNumber} is eqaul to 2 and has divsors = {string.Join(", ", result)}");
        }
    }
}
