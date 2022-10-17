using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse)
                                 .ToList();

            nums.RemoveAll(n => n < 0);

            /*for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] < 0)
                {
                    nums.RemoveAt(i);
                    i--;
                }
            }*/

            nums.Reverse();

            if (nums.Count == 0)
            {
                Console.WriteLine("empty");
                return;
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
