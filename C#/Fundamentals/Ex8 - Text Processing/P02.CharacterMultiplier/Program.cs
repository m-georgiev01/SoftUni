using System;
using System.Linq;

namespace P02.CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                             .OrderBy(x => x.Length)
                             .ToArray();

            double total = 0;
            for (int i = 0; i < words[0].Length; i++)
            {
                total += (words[0][i] * words[1][i]);
            }

            if (words[0].Length < words[1].Length)
            {
                for (int i = words[0].Length; i < words[1].Length; i++)
                {
                    total += words[1][i];
                }
            }  

            Console.WriteLine(total);
        }
    }
}
