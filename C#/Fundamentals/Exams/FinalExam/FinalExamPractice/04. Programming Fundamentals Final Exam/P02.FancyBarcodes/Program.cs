using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace P02.FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(@#+)(?<barcode>[A-Z][A-Za-z\d]{4,}[A-Z])(@#+)$";
            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                StringBuilder sb = new StringBuilder("00");
                string input = Console.ReadLine();

                Match match = regex.Match(input);
                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                string barcode = match.Groups["barcode"].Value;
                sb.Append(new string(barcode.Where(char.IsDigit).ToArray()));
                if (sb.ToString() != "00")
                {
                    sb.Remove(0, 2);
                }

                Console.WriteLine($"Product group: {sb.ToString()}");
            }
        }
    }
}
