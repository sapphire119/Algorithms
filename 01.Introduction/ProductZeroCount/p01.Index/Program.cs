namespace p01.Index
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = new int[]
            {
                //25,4,20,11,13,15
                //20,20,20,20,20,20,20,20
                720
            };

            var mi = 0;
            var ni = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var element = input[i];

                while (element % 2 == 0)
                {
                    element /= 2;
                    mi++;
                }

                while (element % 5 == 0)
                {
                    element /= 5;
                    ni++;
                }
            }

            Console.WriteLine($@"The number of zeroes are: {Math.Min(mi, ni)}");
        }
    }
}