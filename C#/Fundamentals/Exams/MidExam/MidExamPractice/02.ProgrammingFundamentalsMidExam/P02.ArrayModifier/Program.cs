using System;
using System.Linq;
using System.Numerics;

namespace P02.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] numbers = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(BigInteger.Parse)
                            .ToArray();

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = cmdArgs[0];

                if (currCommand == "swap")
                {
                    int indexOne = int.Parse(cmdArgs[1]);
                    int indexTwo = int.Parse(cmdArgs[2]);

                    numbers = SwapElementsInArray(numbers, indexOne, indexTwo);
                }
                else if (currCommand == "multiply")
                {
                    int indexOne = int.Parse(cmdArgs[1]);
                    int indexTwo = int.Parse(cmdArgs[2]);

                    numbers[indexOne] = numbers[indexOne] * numbers[indexTwo];
                }
                else if (currCommand == "decrease")
                {
                    numbers = numbers.Select(x => x - 1).ToArray();
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static BigInteger[] SwapElementsInArray(BigInteger[] numbers, int indexOne, int indexTwo)
        {
            BigInteger temp = numbers[indexOne];
            numbers[indexOne] = numbers[indexTwo];
            numbers[indexTwo] = temp;

            return numbers;
        }
    }
}
