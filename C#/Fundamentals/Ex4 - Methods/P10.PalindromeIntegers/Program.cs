using System;

namespace P10.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input.ToLower() != "end")
            {
                CheckForPalindromeInts(input);

                input = Console.ReadLine();
            }
        }

        private static void CheckForPalindromeInts(string number)
        {
            string reversedNum = string.Empty;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                reversedNum += number[i];
            }

            if (reversedNum == number)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
