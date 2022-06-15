using System;

namespace P08.TennisRanklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int tournaments = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());

            double totalPoints = startingPoints;
            int countWins = 0;

            for (int i = 0; i < tournaments; i++)
            {
                string stage = Console.ReadLine();

                switch (stage)
                {
                    case "W":
                        totalPoints += 2000;
                        countWins++;
                        break;

                    case "F":
                        totalPoints += 1200;
                        break;

                    case "SF":
                        totalPoints += 720;
                        break;

                    default:
                        break;
                }
            }
            double avgPoints = (totalPoints - startingPoints) / tournaments;

            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {Math.Floor(avgPoints)}");
            Console.WriteLine($"{(((double)countWins / tournaments) * 100):F2}%");
        }
    }
}
