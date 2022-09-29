using System;

namespace P12.RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            bool isSpecial = false;

            for (int i = 1; i <= n; i++)
            {
                int currentSum = 0;
                int currentNum = i;

                while (currentNum > 0)
                {
                    currentSum += currentNum % 10;
                    currentNum = currentNum / 10;
                }
                isSpecial = (currentSum == 5) || (currentSum == 7) || (currentSum == 11);
                Console.WriteLine("{0} -> {1}", i, isSpecial);
                currentSum = 0;
            }

        }
    }
}
