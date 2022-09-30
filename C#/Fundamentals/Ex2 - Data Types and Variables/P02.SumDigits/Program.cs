using System;

namespace P02.SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int currNum = int.Parse(Console.ReadLine());

            int sumOfDigits = 0;

            while (currNum > 0)
            {
                int currDigit = currNum % 10;
                sumOfDigits += currDigit;
                currNum /= 10;
            }

            Console.WriteLine(sumOfDigits);
        }
    }
}
