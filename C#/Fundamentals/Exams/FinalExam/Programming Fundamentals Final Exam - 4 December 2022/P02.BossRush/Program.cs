using System;
using System.Text.RegularExpressions;

namespace P02.BossRush
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\|(?<name>[A-Z]{4,})\|:#(?<title>[A-Za-z]+\s{1}[A-Za-z]+)#";
            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);

                if (!match.Success)
                {
                    Console.WriteLine("Access denied!");
                    continue;
                }

                string name = match.Groups["name"].Value;
                string title = match.Groups["title"].Value;

                Console.WriteLine($"{name}, The {title}");
                Console.WriteLine($">> Strength: {name.Length}");
                Console.WriteLine($">> Armor: {title.Length}");
            }
        }
    }
}
