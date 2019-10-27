namespace p07.Roman2Decimal
{
    using System;

    public class Program
    {
        public static void Main()
        {
            //MCMLXXIX
            var input = "XXL";
            var result = 0;
            var value = 0;
            var oldValue = 1000;
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case 'I': value += 1; break;
                    case 'V': value += 5; break;
                    case 'X': value += 10; break;
                    case 'L': value += 50; break;
                    case 'C': value += 100; break;
                    case 'D': value += 500; break;
                    case 'M': value += 1000; break;
                    default:
                        throw new ArgumentException($"Invalid symbol! {input[i]}");
                }

                result += value;
                if (value > oldValue)
                {
                    result -= 2 * oldValue;
                }

                oldValue = value;
                value = 0;
            }

            Console.WriteLine($"The number converted to decimal is: {result}");
        }
    }
}
