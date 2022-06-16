using System;

namespace P04.SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            int count = 0;
            bool isFound = false;

            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    count++;
                    int sum = i + j;

                    if (sum == magicNum)
                    {
                        isFound = true;
                        Console.WriteLine($"Combination N:{count} ({i} + {j} = {magicNum})");
                        break;
                    }                    
                }
                if (isFound)
                {
                    break;
                }
            }
            if (!isFound)
            {
                Console.WriteLine($"{count} combinations - neither equals {magicNum}");
            }
        }
    }
}
