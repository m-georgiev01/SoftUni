using System;

namespace P10.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string absValue = Math.Abs(int.Parse(input)).ToString();

            int evenSum = GetSumEven(absValue);
            int oddSum = GetSumOdd(absValue);

            Console.WriteLine(evenSum * oddSum);
        }

        static int GetSumEven(string input)
        {
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int currNum = int.Parse(input[i].ToString());

                if (currNum % 2 == 0)
                {
                    sum += currNum;
                }
            }
            return sum;
        }

        static int GetSumOdd(string input)
        {
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int currNum = int.Parse(input[i].ToString());

                if (currNum % 2 != 0)
                {
                    sum += currNum;
                }
            }
            return sum;
        }
    }
}
