using System;

namespace P06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            PrintMidChar(input);
        }
        private static void PrintMidChar(string input)
        {
            int index = input.Length / 2;

            if (input.Length % 2 != 0)
            {
                Console.WriteLine(input[index]);
                return;
            }
            else
            {
                Console.WriteLine($"{input[index - 1]}{input[index]}");
            }
        }
    }
}
