using System;
using System.Text.RegularExpressions;

namespace P06.ExtractEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<=\s)[a-zA-Z0-9]+[\.\-_]?[a-zA-Z0-9]*@([a-zA-Z]+)([\.\-][a-zA-Z]*)+[a-z]+";

            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            MatchCollection matches = regex.Matches(input);
            foreach (Match item in matches)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
