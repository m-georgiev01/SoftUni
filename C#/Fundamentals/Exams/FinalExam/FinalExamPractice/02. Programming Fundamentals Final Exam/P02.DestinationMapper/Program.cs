using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P02.DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> destinations = new List<string>();
            string pattern = @"(=|/)(?<destination>[A-Z][A-Za-z]{2,})\1";

            string locations = Console.ReadLine();
            int travelPoints = 0;
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(locations);
            foreach (Match item in matches)
            {
                travelPoints += item.Groups["destination"].Value.Length;
                destinations.Add(item.Groups["destination"].Value);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
