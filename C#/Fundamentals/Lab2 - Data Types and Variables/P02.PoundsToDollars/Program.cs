using System;

namespace P02.PoundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            double poundsUK = double.Parse(Console.ReadLine());

            double dollarsUS = poundsUK * 1.31;

            Console.WriteLine($"{dollarsUS:F3}");
        }
    }
}
