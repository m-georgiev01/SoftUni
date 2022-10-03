using System;

namespace P04.ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strArr = Console.ReadLine().Split(" ");

            Array.Reverse(strArr);

            Console.WriteLine(String.Join(' ', strArr));
        }
    }
}
