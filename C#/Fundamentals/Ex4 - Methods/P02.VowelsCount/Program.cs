using System;

namespace P02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            CountVowels(input);
        }
        private static void CountVowels(string input)
        {
            int vowelsCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string currChar = input[i].ToString().ToLower();
                if ("aeiou".Contains(currChar))
                {
                    vowelsCount++;
                }
            }

            Console.WriteLine(vowelsCount);
        }
    }
}
