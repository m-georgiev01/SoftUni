using System;

namespace P07.FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int chickenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int veganMenu = int.Parse(Console.ReadLine());

            double menusPrice = chickenMenu * 10.35 + fishMenu * 12.4 + veganMenu * 8.15;
            double dessert = menusPrice * 0.2;

            double total = menusPrice + dessert + 2.5;
            Console.WriteLine($"{total}");
        }
    }
}
