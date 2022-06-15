using System;

namespace P06.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            int totalSlices = width * lenght;
            bool isSmall = false;

            while (command != "STOP")
            {
                int takenSlices = int.Parse(command);

                totalSlices -= takenSlices;
                if (totalSlices < 0)
                {
                    isSmall = true;
                    Console.WriteLine($"No more cake left! You need {Math.Abs(totalSlices)} pieces more.");
                    break;
                }

                command = Console.ReadLine();
            }

            if (isSmall == false)
            {
                Console.WriteLine($"{totalSlices} pieces are left.");
            }
        }
    }
}
