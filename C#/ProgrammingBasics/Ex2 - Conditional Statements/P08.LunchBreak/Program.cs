using System;

namespace P08.LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string seriesName = Console.ReadLine();
            int episodeLenght = int.Parse(Console.ReadLine());
            int lunchBreakLenght = int.Parse(Console.ReadLine());

            double timeForLunch = (double)lunchBreakLenght / 8;
            double timeForRest = (double)lunchBreakLenght / 4;

            double freeTime = lunchBreakLenght - (timeForLunch + timeForRest);


            if (freeTime >= episodeLenght)
            {
                Console.WriteLine($"You have enough time to watch {seriesName} and left with {Math.Ceiling(freeTime - episodeLenght)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {seriesName}, you need {Math.Ceiling(episodeLenght - freeTime)} more minutes.");
            }
        }
    }
}
