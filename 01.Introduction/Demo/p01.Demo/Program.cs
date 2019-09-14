namespace p01.Demo
{
    using System;
    using System.Globalization;

    public static class Program
    {
        public static void Main()
        {
            var input = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            var decimalNumbers = Math.Abs(input) % 1.0M;
            var wholeNumbers = Math.Abs(input) - decimalNumbers;

            int decimalDigits;
            int wholeDigits;
            for (decimalDigits = 0; (decimalNumbers.Normalize() % 1.0M) != 0.0M; decimalNumbers *= 10M, decimalDigits++);
            for (wholeDigits = 0; wholeNumbers > 1.0M; wholeNumbers /= 10.0M, wholeDigits++);

            Console.WriteLine("Total digits are: {0}", wholeDigits + decimalDigits);
        }

        public static decimal Normalize(this decimal value)
        {
            return value / 1.000000000000000000000000000000000M;
        }
    }
}
