using System;

namespace P01.NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int currentNum = 1;
            bool isBigger = false;

            for (int rows = 1; rows <= n; rows++)
            {
                for (int col = 1; col <= rows; col++)
                {
                    Console.Write($"{currentNum} ");
                    currentNum++;

                    if (currentNum > n)
                    {
                        isBigger = true;
                        break;
                    }
                }
                if (isBigger)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
