using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace P02.EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> coolEmojies = new List<string>();
            string pattern = @"(::|\*\*)(?<emoji>[A-Z][a-z]{2,})\1";
            Regex regex  = new Regex(pattern);

            string input = Console.ReadLine();

            BigInteger coolThreshold = input.Where(char.IsDigit).Select(x => int.Parse(x.ToString())).Aggregate((a, x) => a * x);
            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                string emoji = match.Groups["emoji"].Value;
                int currEmojiSum= emoji.ToCharArray().Select(x => (int)x).Sum();
                if (currEmojiSum >= coolThreshold)
                {
                    coolEmojies.Add(match.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
            Console.WriteLine(string.Join(Environment.NewLine, coolEmojies));
        }
    }
}
