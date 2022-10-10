using System;

namespace P09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string valuesType = Console.ReadLine();
            string firstValue = Console.ReadLine();
            string secondValue = Console.ReadLine();

            if (valuesType == "int")
            {
                int firstInt = int.Parse(firstValue);
                int secondInt = int.Parse(secondValue);

                GetMax(firstInt, secondInt);
            }
            else if (valuesType == "char")
            {
                char firstChar = char.Parse(firstValue);
                char secondChar = char.Parse(secondValue);

                GetMax(firstChar, secondChar);
            }
            else if (valuesType == "string")
            {
                GetMax(firstValue, secondValue);
            }

        }

        static void GetMax(int a, int b)
        {
            if (a > b)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }
        }
        static void GetMax(char a, char b)
        {
            if (a > b)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }
        }
        static void GetMax(string a, string b)
        {
            int result = a.CompareTo(b);

            if (result > 0)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }
        }
    }
}
