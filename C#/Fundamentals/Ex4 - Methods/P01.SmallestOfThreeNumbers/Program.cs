using System;

namespace P01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[3];

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }

            FindSmallestNum(nums);
        }
        private static void FindSmallestNum(int[] nums)
        {
            int smallestNum = int.MaxValue;

            foreach (var number in nums)
            {
                if (number < smallestNum)
                {
                    smallestNum = number;
                }
            }

            Console.WriteLine(smallestNum);
        }
    }
}
