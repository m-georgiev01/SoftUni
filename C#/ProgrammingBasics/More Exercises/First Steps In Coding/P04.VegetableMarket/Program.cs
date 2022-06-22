using System;

namespace P04.VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double vegPerKg = double.Parse(Console.ReadLine());
            double fruitsPerKg = double.Parse(Console.ReadLine());
            int veg = int.Parse(Console.ReadLine());
            int fruits = int.Parse(Console.ReadLine());

            Console.WriteLine($"{((veg * vegPerKg + fruits * fruitsPerKg) / 1.94):F2}");
        }
    }
}
