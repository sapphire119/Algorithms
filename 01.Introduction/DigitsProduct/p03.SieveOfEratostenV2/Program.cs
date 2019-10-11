namespace p03.SieveOfEratostenV2
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class Program
    {
        //await Task.WhenAll(a);

        public static void Main()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            int input = 200;

            var matrix = new int[input];

            for (int i = 0; i < input; i++) matrix[i] = 0;

            SieveOfEratosten(matrix, input);

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
        }

        private static void SieveOfEratosten(int[] elements, int limit)
        {
            int i = 2, j = 2;

            while (i < limit)
            {
                if (elements[i] == 0)
                {
                    Console.WriteLine($"{i}");
                    j = i * i;
                    while (j < limit)
                    {
                        elements[j] = 1;
                        j += i;
                    }
                }
                i++;
            }
        }
    }
}
