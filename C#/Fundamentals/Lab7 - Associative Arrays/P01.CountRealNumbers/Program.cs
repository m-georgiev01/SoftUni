using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numOccurrences = new SortedDictionary<double, int>();

            double[] nums = Console.ReadLine()
                            .Split()
                            .Select(double.Parse)
                            .ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!numOccurrences.ContainsKey(nums[i]))
                {
                    numOccurrences.Add(nums[i], 0);
                }

                numOccurrences[nums[i]]++;
            }

            foreach (var (key, value) in numOccurrences)
            {
                Console.WriteLine($"{key} -> {value}");
            }
        }
    }
}
