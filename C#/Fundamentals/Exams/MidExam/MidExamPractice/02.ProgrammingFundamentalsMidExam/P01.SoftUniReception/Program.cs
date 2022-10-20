using System;

namespace P01.SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int employeeOneEfficiency = int.Parse(Console.ReadLine());
            int employeeTwoEfficiency = int.Parse(Console.ReadLine());
            int employeeThreeEfficiency = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int efficiencyPerHour = employeeOneEfficiency + employeeTwoEfficiency + employeeThreeEfficiency;

            int hoursCounter = 1;
            while (studentsCount > 0)
            {
                //every 4th hour they take a break
                if (hoursCounter % 4 == 0)
                {
                    hoursCounter++;
                    continue;
                }
                studentsCount -= efficiencyPerHour;
                hoursCounter++;
            }

            Console.WriteLine($"Time needed: {hoursCounter - 1}h.");
        }
    }
}
