using System;

namespace P03.DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double depositedAmount = double.Parse(Console.ReadLine());
            int depositTime = int.Parse(Console.ReadLine());
            double interestRate = double.Parse(Console.ReadLine());

            double totalEndOfPeriod = depositedAmount + depositTime * ((depositedAmount * (interestRate / 100)) / 12);

            Console.WriteLine(totalEndOfPeriod);
        }
    }
}
