using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace P02.AdAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\||\#)(?<name>[A-Za-z ]+)\1(?<exparationDate>\d{2}/\d{2}/\d{2})\1(?<calories>\d{1,5})\1";

            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            int totalCalories = 0;

            MatchCollection matchCollection = Regex.Matches(text, pattern);
            foreach (Match item in matchCollection)
            {


                string name = item.Groups["name"].Value;
                string exparationDate = item.Groups["exparationDate"].Value;
                int calories = int.Parse(item.Groups["calories"].Value);
                totalCalories += calories;

                sb.AppendLine($"Item: {name}, Best before: {exparationDate}, Nutrition: {calories}");
            }

            int daysNeeded = totalCalories / 2000;

            Console.WriteLine($"You have food to last you for: {daysNeeded} days!");
            Console.WriteLine(sb.ToString());
        }
    }
}
