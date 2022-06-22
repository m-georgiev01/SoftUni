using System;

namespace P06.Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            double mackerelPerKg = double.Parse(Console.ReadLine()); 
            double spratPerKg = double.Parse(Console.ReadLine()); 
            double bonitoKg = double.Parse(Console.ReadLine());
            double saurelsKg = double.Parse(Console.ReadLine());
            int bivalviaKg = int.Parse(Console.ReadLine());

            double saurelPerKg = spratPerKg * 1.8;
            double bonitoPerKg = mackerelPerKg * 1.6;

            Console.WriteLine($"{bonitoKg * bonitoPerKg + saurelsKg * saurelPerKg + bivalviaKg * 7.5:F2}");
        }
    }
}
