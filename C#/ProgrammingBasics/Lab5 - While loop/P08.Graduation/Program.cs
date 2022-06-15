using System;

namespace P08.Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int years = 1;
            int countFailedYears = 0;
            double sumGrades = 0;

            

            while (years <= 12)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade >= 4)
                {
                    years++;
                    sumGrades += grade;
                }
                else
                {
                    countFailedYears++;

                    if (countFailedYears > 1)
                    {
                        Console.WriteLine($"{name} has been excluded at {--years} grade");
                        break;
                    }

                    years++;
                }
            }

            double avg = sumGrades / --years;

            if (countFailedYears < 2)
            {
                Console.WriteLine($"{name} graduated. Average grade: {avg:F2}");
            }

        }
    }
}
