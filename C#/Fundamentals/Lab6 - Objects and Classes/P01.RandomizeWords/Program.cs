using System;

namespace P01.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
             string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Random rnd = new Random();

            for (int i = 0; i < words.Length - 1; i++)
            {
                int index = rnd.Next(0, words.Length);
                string temp = words[i];
                words[i] = words[index];
                words[index] = temp;
            }

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
