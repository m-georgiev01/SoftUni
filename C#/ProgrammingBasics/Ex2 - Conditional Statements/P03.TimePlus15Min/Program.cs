using System;

namespace P03.TimePlus15Min
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int totalTime = hours * 60 + minutes + 15;
            int totalHours = totalTime / 60;
            int totalMin = totalTime % 60;

            if (totalHours > 23)
            {
                totalHours -= 24;
            }

            if (totalMin < 10)
            {
                Console.WriteLine($"{totalHours}:0{totalMin}");
            }
            else
            {
                Console.WriteLine($"{totalHours}:{totalMin}");
            }
        }
    }
}
