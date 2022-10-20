using System;
using System.Linq;

namespace P02.TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int waitingPeople = int.Parse(Console.ReadLine());
            int[] wagons = Console.ReadLine()
                           .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .ToArray();

            for (int i = 0; i < wagons.Length; i++)
            {
                while (wagons[i] < 4)
                {
                    if (waitingPeople > 0)
                    {
                        waitingPeople--;
                        wagons[i]++;
                    }

                    if (waitingPeople == 0)
                    {
                        break;
                    }
                }
            }

            if (waitingPeople == 0 && !wagons.All(x => x == 4))
            {
                Console.WriteLine("The lift has empty spots!");
            }
            else if (waitingPeople > 0 && wagons.All(x => x == 4))
            {
                Console.WriteLine($"There isn't enough space! {waitingPeople} people in a queue!");
            }

            Console.WriteLine(string.Join(" ", wagons));

        }
    }
}
