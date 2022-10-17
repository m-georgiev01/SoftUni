using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse)
                                 .ToList();

            List<int> secondList = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse)
                                 .ToList();

            List<int> resultList = new List<int>();

            int smallesCount = firstList.Count > secondList.Count ? secondList.Count : firstList.Count;

            for (int i = 0; i < smallesCount; i++)
            {
                resultList.Add(firstList[i]);
                resultList.Add(secondList[i]);
            }

            if (smallesCount == firstList.Count)
            {
                for (int i = smallesCount; i < secondList.Count; i++)
                {
                    resultList.Add(secondList[i]);
                }
            }
            else
            {
                for (int i = smallesCount; i < firstList.Count; i++)
                {
                    resultList.Add(firstList[i]);
                }
            }

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
