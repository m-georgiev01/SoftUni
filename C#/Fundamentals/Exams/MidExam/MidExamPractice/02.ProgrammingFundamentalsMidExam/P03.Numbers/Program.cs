using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToList();

            List<int> result = numbers.Where(x => x > numbers.Average())
                                      .OrderByDescending(x => x)
                                      .Take(5)
                                      .ToList();

            if (!result.Any())
            {
                Console.WriteLine("No");               
            }
            else if (result.Count < 5)
            {
                for (int i = 0; i < result.Count - 1; i++)
                {
                    Console.Write($"{result[i]} ");
                }
                Console.Write(result[result.Count - 1]);
            }
            else
            {
                Console.WriteLine(string.Join(" ", result)); 
            }
        }
    }
}
