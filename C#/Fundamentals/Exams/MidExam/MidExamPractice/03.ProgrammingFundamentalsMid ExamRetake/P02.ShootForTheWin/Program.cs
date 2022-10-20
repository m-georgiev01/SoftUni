using System;
using System.Linq;

namespace P02.ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToArray();

            int shotTargets = 0;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int index = int.Parse(command);

                //index out of bounds
                if (index < 0 || index >= targets.Length)
                {
                    continue;
                }

                if (targets[index] != -1)
                {
                    int currTarget = targets[index];
                    targets[index] = -1;
                    shotTargets++;

                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i] != -1)
                        {
                            if (targets[i] > currTarget)
                            {
                                targets[i] -= currTarget;
                            }
                            else if (targets[i] <= currTarget)
                            {
                                targets[i] += currTarget;
                            }
                        }
                    }
                }
            }

            Console.Write($"Shot targets: {shotTargets} -> {string.Join(" ", targets)}");
        }
    }
}
