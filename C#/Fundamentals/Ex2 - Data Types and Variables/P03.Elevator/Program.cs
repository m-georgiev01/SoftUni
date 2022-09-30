using System;

namespace P03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int persons = int.Parse(Console.ReadLine());
            int personsPerLift = int.Parse(Console.ReadLine());

            int countFullLifts = persons / personsPerLift;

            if (persons % personsPerLift != 0)
            {
                countFullLifts++;
            }

            Console.WriteLine(countFullLifts);
        }
    }
}
