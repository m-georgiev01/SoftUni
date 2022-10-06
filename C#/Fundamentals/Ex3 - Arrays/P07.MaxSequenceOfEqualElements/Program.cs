using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                        .Split(" ")
                        .Select(int.Parse)
                        .ToArray();

            int index = -1;
            int count = 1;
            int maxCount = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] != nums[i])
                {
                    count = 1;
                }
                else
                {
                    count++;
                }

                if (count > maxCount)
                {
                    index = i;
                    maxCount = count;
                }
            }

            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(nums[index] + " ");
            }
        
        }
    }
}
