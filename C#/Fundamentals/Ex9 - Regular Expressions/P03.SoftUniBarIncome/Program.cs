using System;
using System.Text.RegularExpressions;

namespace P03.SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<name>[A-Z][a-z]+)%([^\|\$%\.]*)<(?<product>\w+)>([^\|\$%\.]*)\|(?<count>\d+)\|([^\|\$%\.\d]*)(?<price>\d+[.]?\d+)\$";
            Regex regex = new Regex(pattern);

            double total = 0;

            string input;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match match = regex.Match(input);
                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    double currPrice = double.Parse(match.Groups["price"].Value);
                    double currTotal = currPrice * count;

                    Console.WriteLine($"{name}: {product} - {currTotal:f2}");
                    total += currTotal;
                }
            }

            Console.WriteLine($"Total income: {total:f2}");
        }
    }
}
