using System;
using System.Linq;

namespace P10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] field = new int[fieldSize];

            int[] initialIndexes = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            foreach (int index in initialIndexes)
            {
                if (index >= 0 && index < field.Length)
                {
                    field[index] = 1;
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int bugIndex = int.Parse(cmdArgs[0]);
                string direction = cmdArgs[1];
                int flyLength = int.Parse(cmdArgs[2]);

                //outside field === invalid index
                if (bugIndex < 0 || bugIndex >= field.Length)
                {
                    continue;
                }

                //there is no ladyBug there so we skip the entire command
                if (field[bugIndex] == 0)
                {
                    continue;
                }

                field[bugIndex] = 0;
                if (direction == "left")
                {
                    flyLength *= -1;
                }

                int nextIndex = bugIndex + flyLength;
                while (nextIndex >= 0 && nextIndex < field.Length && field[nextIndex] == 1)
                {
                    nextIndex += flyLength;
                }

                if (nextIndex < 0 || nextIndex >= field.Length)
                {
                    //ladyBug flew outside the field
                    continue;
                }

                //ladyBug landed on the valid next index
                field[nextIndex] = 1;
            }

            Console.WriteLine(String.Join(" ",field));
        }
    }
}
