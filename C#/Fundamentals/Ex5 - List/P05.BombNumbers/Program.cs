using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                           .Split()
                                           .Select(int.Parse)
                                           .ToList();

            List<int> bombArgs = Console.ReadLine()
                                           .Split()
                                           .Select(int.Parse)
                                           .ToList();

            int bombNumber = bombArgs[0];
            int bombPower = bombArgs[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNumber)
                {
                    int left = i - bombPower;
                    int right = i + bombPower;

                    if (numbers[i] == bombNumber)
                    {
                        if (left < 0)
                        {
                            left = 0;
                        }

                        if (right > numbers.Count)
                        {
                            right = numbers.Count - 1;
                        }

                        numbers.RemoveRange(left, right - left + 1);

                        i = -1;
                    }
                }               
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
