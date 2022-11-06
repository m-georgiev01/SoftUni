using System;
using System.Collections.Generic;

namespace P03.WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wordsSynonyms = new Dictionary<string, List<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonim = Console.ReadLine();

                if (!wordsSynonyms.ContainsKey(word))
                {
                    wordsSynonyms.Add(word, new List<string>());
                }
                wordsSynonyms[word].Add(synonim);
            }

            foreach (var (key, value) in wordsSynonyms)
            {
                Console.WriteLine($"{key} - {string.Join(", ", value)}");
            }
        }
    }
}
