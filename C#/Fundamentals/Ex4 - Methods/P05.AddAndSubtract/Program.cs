using System;

namespace P05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstInt = int.Parse(Console.ReadLine());
            int secondInt = int.Parse(Console.ReadLine());
            int thirdInt = int.Parse(Console.ReadLine());

            Console.WriteLine(SubstractInts(AddTwoInts(firstInt,secondInt),thirdInt));
        }
        private static int AddTwoInts(int a, int b)
        {
            return a + b;
        }
        private static int SubstractInts(int a, int b)
        {
            return a - b;
        }
    }
}
