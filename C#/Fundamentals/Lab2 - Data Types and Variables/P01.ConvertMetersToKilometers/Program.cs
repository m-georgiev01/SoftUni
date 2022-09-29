using System;

namespace P01.ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());

            double cm = m / 1000.00;

            Console.WriteLine($"{cm:F2}");
        }
    }
}
