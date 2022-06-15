using System;

namespace P04.Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            int currentSteps = 0;

            while (command != "Going home")
            {
                int steps = int.Parse(command);

                currentSteps += steps;

                if (currentSteps >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{currentSteps - 10000} steps over the goal!");
                    break;
                }

                command = Console.ReadLine();
            }

            if (command == "Going home")
            {
                int stepsToHome = int.Parse(Console.ReadLine());
                currentSteps += stepsToHome;

                if (currentSteps >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{currentSteps - 10000} steps over the goal!");
                }
                else
                {
                    Console.WriteLine($"{10000 - currentSteps} more steps to reach goal.");
                }
                
            }

        }
    }
}
