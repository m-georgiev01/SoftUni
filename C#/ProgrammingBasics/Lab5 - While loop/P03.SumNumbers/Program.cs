using System;

namespace P03.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());

            int sumEnteredNumbers = 0;

            while (sumEnteredNumbers < firstNumber)
            {              
                int num = int.Parse(Console.ReadLine());
                sumEnteredNumbers += num;
            }

            Console.WriteLine(sumEnteredNumbers);
        }
    }
}
