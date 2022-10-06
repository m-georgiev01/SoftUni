using System;
using System.Linq;

namespace P06.EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                        .Split(" ")
                        .Select(int.Parse)
                        .ToArray();

            bool hasElement = false;

            for (int i = 0; i < nums.Length; i++)
            {
                int leftSum = 0;
                for (int j = 0; j < i; j++)
                {
                    leftSum += nums[j];
                }

                int rightSum = 0;
                for (int k = i + 1; k < nums.Length; k++)
                {
                    rightSum += nums[k];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    hasElement = true;
                }
            }

            if (!hasElement)
            {
                Console.WriteLine("no");
            }
        }
    }
}
