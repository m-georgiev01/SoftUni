using System;

namespace P03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string targetWord = Console.ReadLine();
            string word = Console.ReadLine();

            while (word.Contains(targetWord))
            {
                int index = word.IndexOf(targetWord);
                word = word.Remove(index, targetWord.Length);
            }

            Console.WriteLine(word);
        }
    }
}
