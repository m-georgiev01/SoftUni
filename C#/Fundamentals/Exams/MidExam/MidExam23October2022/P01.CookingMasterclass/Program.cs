using System;

namespace P01.CookingMasterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double flourPrice = double.Parse(Console.ReadLine());
            double eggPrice = double.Parse(Console.ReadLine());
            double apronPrice = double.Parse(Console.ReadLine());

            int freePackages = students / 5;
            double totalCost = apronPrice * Math.Ceiling(students * 1.2)
                               + eggPrice * 10 * students
                               + flourPrice * (students - freePackages);

            if (totalCost <= budget)
            {
                Console.WriteLine($"Items purchased for {totalCost:F2}$.");
            }
            else
            {
                Console.WriteLine($"{(totalCost - budget):F2}$ more needed.");
            }
        }
    }
}
