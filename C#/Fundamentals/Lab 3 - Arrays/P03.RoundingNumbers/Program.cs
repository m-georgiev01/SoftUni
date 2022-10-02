using System;
using System.Linq;

namespace P03.RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine()
                            .Split(" ")
                            .Select(double.Parse)
                            .ToArray();

            int[] roundedNums = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine($"{nums[i]} => {(int)Math.Round(nums[i], MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
