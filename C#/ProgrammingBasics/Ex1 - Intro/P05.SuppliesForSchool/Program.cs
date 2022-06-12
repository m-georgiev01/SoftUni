using System;

namespace P05.SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            int penPackages = int.Parse(Console.ReadLine());
            int markersPackages = int.Parse(Console.ReadLine());
            int cleaningLiquidLiters = int.Parse(Console.ReadLine());
            int discountPercentage = int.Parse(Console.ReadLine());

            double sumWithoutDiscount = (penPackages * 5.80) + (markersPackages * 7.2) + (cleaningLiquidLiters * 1.2);
            double total = sumWithoutDiscount - sumWithoutDiscount * ((double)discountPercentage / 100);

            Console.WriteLine(total);
        }
    }
}
