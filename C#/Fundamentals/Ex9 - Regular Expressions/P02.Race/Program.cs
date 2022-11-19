using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace P02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<name>[A-Za-z]+)|(?<distance>\d)";
            Regex regex = new Regex(pattern);

            string[] names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var participants = new Dictionary<string, int>();
            foreach (var name in names)
            {
                participants.Add(name, 0);
            }

            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                MatchCollection matches = regex.Matches(input);
                int sum = 0;
                StringBuilder currName = new StringBuilder();

                foreach (Match item in matches)
                {
                    if (int.TryParse(item.ToString(), out int n))
                    {
                        sum += n;
                    }
                    else
                    {
                        currName.Append(item.ToString());
                    }
                }

                if (participants.ContainsKey(currName.ToString()))
                {
                    participants[currName.ToString()] += sum;
                }
            }
            participants = participants.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            Console.WriteLine($"1st place: {participants.ElementAt(0).Key}");
            Console.WriteLine($"2nd place: {participants.ElementAt(1).Key}");
            Console.WriteLine($"3rd place: {participants.ElementAt(2).Key}");
        }
    }
}
