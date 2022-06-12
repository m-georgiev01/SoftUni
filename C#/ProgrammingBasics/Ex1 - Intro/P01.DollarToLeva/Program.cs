using System;

namespace P1.DollarToLeva
{
    class Program
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());
            Console.WriteLine(usd * 1.79549);
        }
    }
}
