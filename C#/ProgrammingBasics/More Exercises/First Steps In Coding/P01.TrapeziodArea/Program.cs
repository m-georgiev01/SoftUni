using System;

namespace P01.TrapeziodArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double b1 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            Console.WriteLine($"{((b1 + b2) * h / 2):F2}");
        }
    }
}
