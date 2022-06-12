using System;

namespace P01.SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTimeInSeconds = int.Parse(Console.ReadLine());
            int secondTimeInSeconds = int.Parse(Console.ReadLine());
            int thirdTimeInSeconds = int.Parse(Console.ReadLine());

            int sumTime = firstTimeInSeconds + secondTimeInSeconds + thirdTimeInSeconds;
            int min = sumTime / 60;
            int sec = sumTime % 60;

            if (sec < 10)
            {
                Console.WriteLine($"{min}:0{sec}");
            }
            else
            {
                Console.WriteLine($"{min}:{sec}");
            }

        }
    }
}
