namespace p01.Index
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class Program
    {
        public static void Main()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var number = double.Parse(input, CultureInfo.InvariantCulture);
                var @base = int.Parse(Console.ReadLine());

                //E9E.37658B7513
                var result = new List<char>();
                if (number < 0)
                {
                    number = -number;
                    result.Add('-');
                }

                var numbWholePart = GetWholeNumbPart((int)Math.Truncate(number), @base);
                var decimalPart = GetDecimaPart(Math.Abs(Math.Truncate(number) - number), @base, 10);

                if (numbWholePart.Count > 0 && decimalPart.Count > 0)
                {
                    result.AddRange(numbWholePart);
                    result.Add('.');
                    result.AddRange(decimalPart);
                }
                else if (numbWholePart.Count > 0 && decimalPart.Count < 1)
                {
                    result.AddRange(numbWholePart);
                }
                else if (numbWholePart.Count < 1 && decimalPart.Count > 0)
                {
                    result.Add('0');
                    result.Add('.');
                    result.AddRange(decimalPart);
                }

                Console.WriteLine($"Resulting number is: {string.Join("", result)} in base ({@base})");
            }
            //var test = GetDecimaPart(0.125, 2, 10);
        }

        private static List<char> GetDecimaPart(double decimalPart, int @base, int accuracy)
        {
            var list = new List<char>();
            while (accuracy > 0 && Math.Abs(decimalPart) != 0.0)
            {
                var temp = decimalPart * @base;
                list.Add(GetChar((int)Math.Floor(temp)));
                decimalPart = temp - (int)Math.Floor(temp);
                accuracy--;
            }

            return list;
        }

        private static List<char> GetWholeNumbPart(int tempWholePartNumber, int @base)
        {
            var list = new List<char>();

            while (tempWholePartNumber > 0)
            {
                list.Add(GetChar(tempWholePartNumber % @base));
                tempWholePartNumber /= @base;
            }

            return ReverseValues(list);
            //Console.WriteLine(string.Join("", ));
        }

        private static List<T> ReverseValues<T>(List<T> list)
        {
            var reversedList = new List<T>();
            for (int i = list.Count - 1; i >= 0; i--) 
            {
                reversedList.Add(list[i]);
            }
            return reversedList;
        }

        private static char GetChar(int temp)
        {
            var characterVal = temp < 10 ? temp + '0' : temp + 'A' - 10;
            var result = (char)characterVal;
            return result;
        }
    }
}
