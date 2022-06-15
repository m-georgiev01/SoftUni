using System;

namespace P02.ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxPoorGrades = int.Parse(Console.ReadLine());
            string task = Console.ReadLine();
            int grade = int.Parse(Console.ReadLine());

            int countPoorGrades = 0;
            bool isFailed = false;
            int countGrades = 0;
            double sumGrades = 0;
            string lastProblem = "";

            while (task != "Enough")
            {
                if (grade <= 4)
                {
                    countPoorGrades++;

                    if (countPoorGrades == maxPoorGrades)
                    {
                        isFailed = true;
                        Console.WriteLine($"You need a break, {countPoorGrades} poor grades.");
                        break;
                    }
                }

                countGrades++;
                sumGrades += grade;
                lastProblem = task;

                task = Console.ReadLine();
                if (task == "Enough")
                {
                    break;
                }
                grade = int.Parse(Console.ReadLine());
            }

            if (isFailed == false)
            {
                double avg = sumGrades / countGrades;

                Console.WriteLine($"Average score: {avg:F2}");
                Console.WriteLine($"Number of problems: {countGrades}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
