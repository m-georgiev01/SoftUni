using System;

namespace P04.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string reversedInput = string.Empty;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                char currentChar = input[i];
                reversedInput += currentChar;
            }

            Console.WriteLine(reversedInput);
        }
    }
}
