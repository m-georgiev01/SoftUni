﻿using System;
using System.Linq;

namespace P03.ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr1 = new int[n];
            int[] arr2 = new int[n];

            for (int i = 1; i <= n; i++)
            {
                int[] numbers = Console.ReadLine()
                                .Split(" ")
                                .Select(int.Parse)
                                .ToArray();

                if (i % 2 != 0)
                {
                    arr1[i - 1] = numbers[0];
                    arr2[i - 1] = numbers[1];
                }
                else
                {
                    arr2[i - 1] = numbers[0];
                    arr1[i - 1] = numbers[1];
                }
            }

            Console.WriteLine(String.Join(" ", arr1));
            Console.WriteLine(String.Join(" ", arr2));
        }
    }
}
