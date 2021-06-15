using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, string> func = (y, x) =>
            {
                return new string("DSD" + x*2 + y);
            };

            Console.WriteLine(func(3, 2));
        }
    }
}
