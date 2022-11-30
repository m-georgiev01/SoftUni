using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P02.MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wordPairs = new Dictionary<string, string>();
            string pattern = @"(@|#)(?<firstWord>[A-Za-z]{3,})\1\1(?<secondWord>[A-Za-z]{3,})\1";

            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                var firstWord = match.Groups["firstWord"].Value;
                var secondWord = match.Groups["secondWord"].Value;

                if (firstWord == new string(secondWord.Reverse().ToArray()))
                {
                    wordPairs.Add(firstWord, secondWord);
                }
            }

            Console.WriteLine(matches.Count == 0 ? "No word pairs found!" : $"{matches.Count} word pairs found!");

            if (wordPairs.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", " ,wordPairs.Select(x => x.Key + " <=> " + x.Value)));
            }
        }
    }
}
