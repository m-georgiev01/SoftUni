using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                        .Split(" ")
                        .Select(int.Parse)
                        .ToArray();

            List<int> topInt = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int currNum = nums[i];
                bool isBigger = true;

                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] >= currNum)
                    {
                        isBigger = false;
                        break;
                    }
                }

                if (isBigger)
                {
                    topInt.Add(currNum);
                }
            }
            Console.WriteLine(String.Join(" ",topInt));
        }
    }
}
