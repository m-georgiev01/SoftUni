using System;

namespace P03.CelsiusToFahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            double celsius = double.Parse(Console.ReadLine());

            Console.WriteLine($"{(celsius * 1.8 + 32):F2}");
        }
    }
}
