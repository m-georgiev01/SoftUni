using System;
using System.Linq;

namespace P08.CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            while (nums.Length > 1)
            {
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    if (i >= nums.Length)
                    {
                        break;
                    }
                    nums[i] += nums[i + 1];
                }
                nums = nums.Take(nums.Count() - 1).ToArray();
            }
            Console.WriteLine(nums[0]);
        }
    }
}
