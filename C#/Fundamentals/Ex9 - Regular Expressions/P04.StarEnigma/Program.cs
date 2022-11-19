using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P04.StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            int n = int.Parse(Console.ReadLine());
            string decryptionPattern = @"[STARstar]";
            Regex regex = new Regex(decryptionPattern);

            for (int i = 0; i < n; i++)
            {
                string encryptedMsg = Console.ReadLine();
                int decryptionKey = regex.Matches(encryptedMsg).Count;
                string decryptedMsg = new string (encryptedMsg.Select(x => (char)(x - decryptionKey)).ToArray());

                string breakingPattern = @"@(?<planetName>[A-Za-z]+)([^@\-!:>])*:(?<population>\d+)([^@\-!:>])*!(?<attackType>[AD])!([^@\-!:>])*->(?<soldierCount>\d+)";
                Match match = Regex.Match(decryptedMsg, breakingPattern);

                string planetName = match.Groups["planetName"].Value;
                string population = match.Groups["population"].Value;
                string attackType = match.Groups["attackType"].Value;
                string soldierCount = match.Groups["soldierCount"].Value;

                if (attackType == "A")
                {
                    attackedPlanets.Add(planetName);
                }
                else if (attackType == "D")
                {
                    destroyedPlanets.Add(planetName);
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var planetName in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planetName}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var planetName in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planetName}");
            }
        }
    }
}
