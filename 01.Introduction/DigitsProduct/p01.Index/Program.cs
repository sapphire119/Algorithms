namespace p01.Index
{
    using System;
    using System.Globalization;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            //Can calculate up to 20;
            var input = int.Parse(Console.ReadLine());


            var isPrime = PrimeCheck(input);
            Console.WriteLine(isPrime);
        }

        
        private static bool PrimeCheck(int number)
        {
            var factorial = Factorial(number - 1);

            var remainder = factorial % number;

            if (number - 1 == remainder) return true;

            return false;
        }

        private static long Factorial(long number)
        {
            if (number <= 0)
            {
                return 1;
            }

            return number * Factorial(number - 1);
        }
    }
}
