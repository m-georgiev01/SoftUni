using System;

namespace P06.WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentRecordTime = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());

            //za koeto pluva 1m
            double timeInSec = double.Parse(Console.ReadLine());

            double time = distanceInMeters * timeInSec;

            double waterResistanceInSec = Math.Floor(distanceInMeters / 15) * 12.5;

            double finalTime = time + waterResistanceInSec;

            if (finalTime < currentRecordTime)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {finalTime:F2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {(finalTime - currentRecordTime):F2} seconds slower.");
            }
        }
    }
}
