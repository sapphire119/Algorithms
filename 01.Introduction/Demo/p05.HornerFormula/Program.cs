namespace p05.HornerFormula
{
    using System;
    using System.Globalization;

    public class Program
    {
        public static void Main()
        {
            var arrChar = "12734".ToCharArray();
            //var @base = 8;
            //var result = Calculate(arrChar, @base);
            //Console.WriteLine(result);

            var arrDoubleChar = "0.001".ToCharArray();
            //;
            //var @base = 2;
            //CalculateLessThan1(arrDoubleChar, @base);



            //Console.WriteLine(CalculateReal(arrChar, 8));

            //Console.WriteLine(CalculateReal(arrDoubleChar, 2));

            //0,302734375
            var tempArr = "3CB.2A".ToCharArray();
            Console.WriteLine(CalculateReal(tempArr, 14));

        }

        private static int GetCharValue(char tempChar)
        {
            return tempChar >= '0' && tempChar <= '9' ? tempChar - '0' : tempChar - 'A' + 10;
        }

        private static int Calculate(char[] arrChar, int @base)
        {
            var result = 0;
            for (int i = 0; i < arrChar.Length; i++)
            {
                result = ((result * @base) + GetCharValue(arrChar[i]));
            }

            return result;
        }

        private static double CalculateLessThan1(char[] arrChar, int @base)
        {
            //arrChar = (new string(arrChar)).Split('.')[1].ToCharArray();

            var result = 0.0;
            for (int i = arrChar.Length - 1; i >= 0; i--)
            {
                result = (result + GetCharValue(arrChar[i])) / (double)@base;
            }

            return result;
        }

        private static string CalculateReal(char[] arrRealChar, int @base)
        {
            var result = string.Empty;
            var minus = 1;

            if ('-' == arrRealChar[0]) { minus = -1; arrRealChar[0] = '0'; }

            var numb = new string(arrRealChar);
            if (!numb.Contains(".")) return result += Calculate(arrRealChar, @base);

            var wholePart = GetPartOfCharArr(numb);
            var decimalPart = GetPartOfCharArr(numb, 1);

            var wholeNum = Calculate(wholePart, @base);
            var decimalNum = CalculateLessThan1(decimalPart, @base);

            var temp = (wholeNum + decimalNum) * minus;

            result += temp.ToString();

            return result;
        }

        private static char[] GetPartOfCharArr(string number, int indexPart = 0)
        {
            return number.Split(".")[indexPart].ToCharArray();
        }
    }
}
