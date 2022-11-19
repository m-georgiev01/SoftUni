using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P05.NetherRealms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> decryptedDemons = new List<string>();
            string[] demons = Console.ReadLine().Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);

            string healthPattern = @"[^0-9+\-*/.]";
            string dmgPattern = @"[+-]?\d+[.]?\d*";

            foreach (var demon in demons)
            {
                
                int health = Regex.Matches(demon, healthPattern).Select(x => (int)char.Parse(x.Value)).Sum();
                double dmg = Regex.Matches(demon, dmgPattern).Select(x => double.Parse(x.Value)).Sum();

                foreach (var symbol in demon.Where(x => x == '/' || x == '*'))
                {
                    if (symbol == '/')
                    {
                        dmg /= 2.0;
                    }
                    else
                    {
                        dmg *= 2.0;
                    }
                }

                string decryptedDemon = $"{demon} - {health} health, {dmg:f2} damage";
                decryptedDemons.Add(decryptedDemon);
            }

            Console.WriteLine(string.Join(Environment.NewLine, decryptedDemons.OrderBy(x => x)));
        }
    }
}
