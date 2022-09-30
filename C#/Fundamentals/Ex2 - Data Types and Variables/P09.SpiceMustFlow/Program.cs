using System;
using System.Numerics;

namespace P09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());

            int countMiningDays = 0;
            BigInteger extractedAmount = 0;

            while (startingYield >= 100)
            {
                extractedAmount += startingYield;
                countMiningDays++;
                startingYield -= 10;
                extractedAmount -= 26;
            }
            if (extractedAmount > 0)
            {
                extractedAmount -= 26;
            }
           
            Console.WriteLine(countMiningDays);
            Console.WriteLine(extractedAmount);
        }
    }
}
