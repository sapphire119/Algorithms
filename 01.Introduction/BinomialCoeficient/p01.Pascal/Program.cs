namespace p01.Pascal
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var n = 7;
            var k = 3;
            long[] lastLine = new long[1000];

            lastLine[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                lastLine[i] = 1;

                for (int j = i - 1 > k ? k : i - 1; j >= 1; j--) 
                {
                    //if (j > k) j = k;
                    lastLine[j] += lastLine[j - 1];
                }
            }

            Console.WriteLine("C({0},{1}) = {2}", n, k, lastLine[k]);
        }
    }
}