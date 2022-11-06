using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P02.OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wordOccurrences = new Dictionary<string, int>();

            string[] words = Console.ReadLine().Split().Select(x => x.ToLower()).ToArray(); ;

            foreach (var word in words)
            {
                if (!wordOccurrences.ContainsKey(word))
                {
                    wordOccurrences.Add(word, 0);
                }

                wordOccurrences[word]++;
            }

            var x = wordOccurrences.Where(x => x.Value % 2 != 0)
                            .ToDictionary(k => k.Key, v => v.Value)
                            .Keys;

            Console.WriteLine(string.Join(" ", x));
        }
    }
}
