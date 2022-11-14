using System;

namespace P04.TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (var bW in bannedWords)
            {
                text = text.Replace(bW, new string('*', bW.Length));
            }

            Console.WriteLine(text);
        }
    }
}
