using System;

namespace P01.BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int lectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            double maxBonus = double.MinValue;
            int maxAttendedLectures = 0;

            for (int i = 0; i < students; i++)
            {
                int studentAttendance = int.Parse(Console.ReadLine());

                double totalBonus = (double)studentAttendance / lectures * (5 + additionalBonus);

                if (maxBonus < totalBonus)
                {
                    maxBonus = totalBonus;
                    maxAttendedLectures = studentAttendance;
                }
            }

            if (maxBonus == double.MinValue)
            {
                maxBonus = 0;
            }
            Console.WriteLine($"Max Bonus: {Math.Round(maxBonus)}.");
            Console.WriteLine($"The student has attended {maxAttendedLectures} lectures.");
        }
    }
}
