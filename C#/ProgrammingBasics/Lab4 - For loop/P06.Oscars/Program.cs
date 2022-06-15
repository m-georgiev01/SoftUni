using System;

namespace P06.Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double startingPoints = double.Parse(Console.ReadLine());
            int judgesCount = int.Parse(Console.ReadLine());

            double totalPoints = startingPoints;

            for (int i = 0; i < judgesCount; i++)
            {
                string judge = Console.ReadLine();
                double points = double.Parse(Console.ReadLine());

                totalPoints += (judge.Length * points) / 2;

                if (totalPoints > 1250.5)
                {
                    Console.WriteLine($"Congratulations, {name} got a nominee for leading role with {totalPoints:F1}!");
                    break;
                }
            }

            if (totalPoints <= 1250.5)
            {
                Console.WriteLine($"Sorry, {name} you need {(1250.5 - totalPoints):F1} more!");
            }
        }
    }
}
