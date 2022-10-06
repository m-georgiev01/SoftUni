using System;
using System.Linq;

namespace P08.MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                        .Split(" ")
                        .Select(int.Parse)
                        .ToArray();

            int testNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == testNum)
                    {
                        Console.WriteLine($"{nums[i]} {nums[j]}");
                    }
                }
            }
        }
    }
}
