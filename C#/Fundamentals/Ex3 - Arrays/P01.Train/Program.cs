using System;

namespace P01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] peopleOnTrain = new int[n];

            int total = 0;

            for (int i = 0; i < peopleOnTrain.Length; i++)
            {
                peopleOnTrain[i] = int.Parse(Console.ReadLine());
                total += peopleOnTrain[i];
            }

            Console.WriteLine(String.Join(" ", peopleOnTrain));
            Console.WriteLine(total);
        }
    }
}
