using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace p04.Awaiter
{
    public static class Program
    {
        //await Task.WhenAll(a);

        public async static void Main()
        {
            int input = 200;

            //var matrix = new int[input];
            //var asd = new int[3000000];

            //1_000_000 requests
            //var a = asd.ToList().Select(x => SendRequest(x));

            //await Task.WhenAll(a);


            await "pesho";

            Console.WriteLine("aasd");
        }

        public static Awaiter GetAwaiter(this string s)
        {
            throw new NotImplementedException();
        }
        public abstract class Awaiter : INotifyCompletion
        {
            public abstract bool IsCompleted { get; }

            public abstract void GetResult();

            public abstract void OnCompleted(Action continuation);
        }

        public static async Task SendRequest(int a)
        {

        }


    }
}
