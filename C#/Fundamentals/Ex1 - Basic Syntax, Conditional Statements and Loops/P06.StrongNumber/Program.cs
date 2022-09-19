using System;

namespace P06.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < number.ToString().Length; i++)
            {
                char currentDigit = number.ToString()[i];

                int fact = 1;

                for (int j = 2; j <= int.Parse(currentDigit.ToString()); j++)
                {
                    fact *= j;
                }

                sum += fact;
            }

            if (sum == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
