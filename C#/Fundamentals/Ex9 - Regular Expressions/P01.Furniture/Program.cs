using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> boughtItems = new List<string>();
            double total = 0;

            string pattern = @"^>>(?<furnitureName>[A-Za-z]+)<<(?<price>\d+(\.\d+)?)!(?<quantity>\d+)(\.\d+)?$";
            Regex regex = new Regex(pattern);

            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = regex.Match(input);
                if (match.Success)
                {                
                    string furnitureName = match.Groups["furnitureName"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    boughtItems.Add(furnitureName);
                    total += price * quantity;
                }        
            }
            Console.WriteLine("Bought furniture:");
            foreach (var futnitureName in boughtItems)
            {
                Console.WriteLine(futnitureName);
            }
            Console.WriteLine($"Total money spend: {total:f2}");
        }
    }
}
