using System;
using System.Linq;

namespace P07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstSplit = string.Join(" ", Console.ReadLine().Split("|").Reverse().ToList());

            Console.WriteLine(string.Join(" ", firstSplit.Split(" ", StringSplitOptions.RemoveEmptyEntries)));
        }
    }
}
