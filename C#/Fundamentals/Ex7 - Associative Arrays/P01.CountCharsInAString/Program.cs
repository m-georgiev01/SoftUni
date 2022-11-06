using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var charOccurrences = new Dictionary<char,int>();

            char[] arr = Console.ReadLine().ToCharArray();

            foreach (var ch in arr.Where(x => x != ' '))
            {
                if (!charOccurrences.ContainsKey(ch))
                {
                    charOccurrences.Add(ch, 0);
                }
                charOccurrences[ch]++;
            }

            foreach (var (key, value) in charOccurrences)
            {
                Console.WriteLine($"{key} -> {value}"); 
            }
        }
    }
}
