using System;

namespace P02.BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingPoints = int.Parse(Console.ReadLine());
            double bonusPoints;

            if (startingPoints <= 100)
            {
                bonusPoints = 5;
            }
            else if (startingPoints > 1000)
            {
                bonusPoints = startingPoints * 0.1;
            }
            else
            {
                bonusPoints = startingPoints * 0.2;
            }

            if (startingPoints % 2 == 0)
            {
                bonusPoints++;
            }
            else if (startingPoints % 10 == 5)
            {
                bonusPoints += 2;
            }

            Console.WriteLine(bonusPoints);
            Console.WriteLine(startingPoints + bonusPoints);
        }
    }
}
