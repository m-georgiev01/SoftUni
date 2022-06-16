using System;

namespace P05.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                string currentNum = i.ToString();
                int countDivisions = 0;

                for (int j = 0; j < currentNum.Length; j++)
                {
                    int digit = int.Parse(currentNum[j].ToString());

                    if (digit == 0)
                    {
                        continue;
                    }

                    if (n % digit == 0)
                    {
                        countDivisions++;
                    }
                }

                if (countDivisions == 4)
                {
                    Console.Write($"{currentNum} ");
                }
            }
        }
    }
}
