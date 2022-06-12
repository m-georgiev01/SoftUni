using System;

namespace P05.GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double filmBudget = double.Parse(Console.ReadLine());
            int statisti = int.Parse(Console.ReadLine());
            double clothingPrice = double.Parse(Console.ReadLine());

            double filmDecor = filmBudget * 0.1;
            double totalClothingPrice = clothingPrice * statisti;

            if (statisti > 150)
            {
                totalClothingPrice *= 0.9;
            }

            if (filmDecor + totalClothingPrice > filmBudget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {((filmDecor + totalClothingPrice) - filmBudget):F2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {(filmBudget - (filmDecor + totalClothingPrice)):F2} leva left.");
            }
        }
    }
}
