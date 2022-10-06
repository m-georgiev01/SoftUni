using System;
using System.Linq;

namespace P04.ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            int rotationsCount = int.Parse(Console.ReadLine());

            int timesToRotate = rotationsCount % arr.Length;

            for (int i = 1; i <= timesToRotate; i++)
            {
                int firstElement = arr[0];
                for (int j = 1; j < arr.Length; j++)
                {
                    arr[j - 1] = arr[j];
                }
                arr[arr.Length - 1] = firstElement;
            }

            Console.WriteLine(String.Join(" ", arr));
        }
    }
}
