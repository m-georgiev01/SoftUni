using System;

namespace P08.PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogFoodPackages = int.Parse(Console.ReadLine());
            int catFoodPackages = int.Parse(Console.ReadLine());
            double total = dogFoodPackages * 2.5 + catFoodPackages * 4;
            Console.WriteLine($"{total} lv.");
        }
    }
}
