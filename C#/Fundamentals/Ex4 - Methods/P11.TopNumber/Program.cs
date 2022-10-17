using System;

namespace P11.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            PrintTopIntsInRange(end);
        }

        private static void PrintTopIntsInRange(int end)
        {
            for (int i = 1; i <= end; i++)
            {
                bool hasOddDigit = false;
                bool isDivisibleByEigth = false;

                int sum = 0;

                for (int k = 0; k < i.ToString().Length; k++)
                {
                    int currNum = int.Parse(i.ToString()[k].ToString());
                    sum += currNum;

                    if (currNum % 2 != 0)
                    {
                        hasOddDigit = true;
                    }
                }

                if (sum % 8 == 0)
                {
                    isDivisibleByEigth = true;
                }

                if (hasOddDigit && isDivisibleByEigth)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
