using System;

namespace P06.OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());

            double result = 0;

            if ((operation == '/' || operation == '%') && num2 == 0)
            {
                Console.WriteLine($"Cannot divide {num1} by zero");
                return;
            }

            switch (operation)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    result = (double)num1 / num2;
                    break;
                case '%':
                    result = num1 % num2;
                    break;
            }

            if (operation == '+' || operation == '-' || operation == '*')
            {
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{num1} {operation} {num2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{num1} {operation} {num2} = {result} - odd");
                }
            }
            else if (operation == '/')
            {
                Console.WriteLine($"{num1} {operation} {num2} = {result:F2}");
            }
            else if (operation == '%')
            {
                Console.WriteLine($"{num1} {operation} {num2} = {result}");
            }

        }
    }
}
