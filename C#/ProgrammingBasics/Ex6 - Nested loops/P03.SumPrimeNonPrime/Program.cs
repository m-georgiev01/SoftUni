using System;

namespace P03.SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            int sumPrime = 0;
            int sumNonPrime = 0;

            while (command != "stop")
            {
                int count = 0;

                int currentNumber = int.Parse(command);

                if (currentNumber < 0)
                {
                    Console.WriteLine("Number is negative.");
                    command = Console.ReadLine();
                    continue;
                }

                for (int i = 1; i <= currentNumber; i++)
                {
                    if (currentNumber % i == 0)
                    {
                        count++;
                    }
                }

                if (count == 2)
                {
                    sumPrime += currentNumber;
                }
                else
                {
                    sumNonPrime += currentNumber;
                }

                command = Console.ReadLine();
            }

            if (command == "stop")
            {
                Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
                Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");
            }
        }
    }
}
