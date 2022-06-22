using System;

namespace P07.HousePainting
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double sides = 2 * (x * x) - 1.2 * 2 + 2 * (x * y) - 2 * (1.5 * 1.5);
            double roof = 2 * (x * y) + 2 * (x * h / 2);

            Console.WriteLine($"{sides / 3.4:F2}");
            Console.WriteLine($"{roof / 4.3:F2}");
        }
    }
}
