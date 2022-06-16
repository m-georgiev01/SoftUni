using System;

namespace P02.EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            for (int i = num1; i <= num2; i++)
            {
                string current = i.ToString();

                int sumEven = 0;
                int sumOdd = 0;

                for (int j = 0; j < current.Length; j++)
                {
                    int digit = int.Parse(current[j].ToString());

                    if (j % 2 == 0)
                    {
                        sumEven += digit;
                    }
                    else
                    {
                        sumOdd += digit;
                    }
                }

                if (sumOdd == sumEven)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
