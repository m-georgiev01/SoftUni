using System;

namespace P02.TriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            Console.WriteLine($"{((a * h) / 2):F2}");
        }
    }
}
