using System;

namespace P08.LettersChangeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sequences = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            decimal total = 0;

            foreach (var sq in sequences)
            {
                char firstLetter = sq[0];
                decimal number = decimal.Parse(sq.Substring(1, sq.Length - 2));
                char lastLetter = sq[sq.Length - 1];

                int indexFirstLetter = char.ToUpper(firstLetter) - 64;
                int indexLastLetter = char.ToUpper(lastLetter) - 64;

                if (char.IsUpper(firstLetter))
                {
                    number /= indexFirstLetter;
                }
                else
                {
                    number *= indexFirstLetter;
                }

                if (char.IsUpper(lastLetter))
                {
                    number -= indexLastLetter;
                }
                else
                {
                    number += indexLastLetter;
                }
                total += number;
            }

            Console.WriteLine($"{total:F2}");
        }
    }
}
