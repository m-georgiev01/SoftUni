using System;

namespace P08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine($"{(double)FindFactorial(a) / FindFactorial(b):F2}");
        }
        private static long FindFactorial(int a)
        {
            long sum = 1;
            for (int i = 2; i <= a; i++)
            {
                sum *= i;
            }
            return sum;
        }
    }
}
