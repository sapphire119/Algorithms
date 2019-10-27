namespace p06.Decimal2Roman
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static char[][] Roman1_9 =
        {
            new char[] { ' '}, //0
            new char[] { 'A'}, //1
            new char[] { 'A', 'A'}, //2
            new char[] { 'A', 'A', 'A'}, //3
            new char[] { 'A', 'B'}, //4
            new char[] { 'B'}, //5
            new char[] { 'B', 'A'}, //6
            new char[] { 'B', 'A', 'A'}, //7
            new char[] { 'B', 'A', 'A', 'A'}, //8
            new char[] { 'A', 'C'}, //9
            new char[] { 'C'}, //10
        };

        private static char[][] RomanDigits =
        {
            new char[] {'I', 'V', 'X'},
            new char[] {'X', 'L', 'C'},
            new char[] {'C', 'D', 'M' },
            new char[] {'M'}
        };


        public static void Main()
        {
            string input;
            while ("END" != (input = Console.ReadLine()))
            {
                var numb = int.Parse(input);
                DecimalToRoman(numb);
            }
        }

        private static void DecimalToRoman(int input)
        {
            var digit = new List<char>();
            var result = new List<string>();
            for (int power = 0; input > 0; input /= 10, power++)
            {
                var romanDigit = GetRomanDigit(digit, input % 10, power);
                result.Add(romanDigit);
                digit.Clear();
            }
            result.Reverse();
            Console.WriteLine($"The Roman number is: {string.Join("", result)}");
        }

        private static string GetRomanDigit(List<char> digit, int remainder, int power)
        {
            var arr = Roman1_9[remainder];
            for (int k = 0; k < arr.Length; k++)
            {
                if (' ' == arr[k]) return string.Empty;
                var currentDigit = RomanDigits[power][arr[k] - 'A'];
                digit.Add(currentDigit);
            }

            return string.Join("", digit);
        }
    }
}
