using System;

namespace P04.TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int judges = int.Parse(Console.ReadLine());
            string presentation = Console.ReadLine();

            double sumAll = 0;
            int countAll = 0;

            while (presentation != "Finish")
            {
                double sumCurrentPresentation = 0;
                int countCurrentGrades = 0;

                for (int i = 1; i <= judges; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    sumCurrentPresentation += grade;
                    countCurrentGrades++;
                }
                double avgCP = sumCurrentPresentation / countCurrentGrades;
                Console.WriteLine($"{presentation} - {avgCP:F2}.");

                sumAll += avgCP;
                countAll++;

                presentation = Console.ReadLine();
            }

            if (presentation == "Finish")
            {
                double avg = sumAll / countAll;
                Console.WriteLine($"Student's final assessment is {avg:F2}.");
            }
        }
    }
}
