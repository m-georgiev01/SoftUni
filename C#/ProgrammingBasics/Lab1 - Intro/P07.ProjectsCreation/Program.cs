using System;

namespace P07.ProjectsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string archName = Console.ReadLine();
            int projectsCount = int.Parse(Console.ReadLine());

            Console.WriteLine($"The architect {archName} will need {projectsCount * 3} hours to complete {projectsCount} project/s.");
        }
    }
}
