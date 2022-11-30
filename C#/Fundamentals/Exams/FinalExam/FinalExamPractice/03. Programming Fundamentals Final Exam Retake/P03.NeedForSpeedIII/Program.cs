using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.NeedForSpeedIII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cars = new Dictionary<string, int[]>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var carInfo = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                string carName = carInfo[0];
                int milage = int.Parse(carInfo[1]);
                int fuel = int.Parse(carInfo[2]);

                cars.Add(carName, new int[] {milage, fuel});
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                var cmdArgs = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string currCmd = cmdArgs[0];
                string car = cmdArgs[1];

                if (currCmd == "Drive")
                {
                    int distance = int.Parse(cmdArgs[2]);
                    int fuel = int.Parse(cmdArgs[3]);

                    if (cars[car][1] - fuel < 0)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                        continue;
                    }

                    cars[car][0] += distance;
                    cars[car][1] -= fuel;
                    Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                    if (cars[car][0] >= 100_000)
                    {
                        cars.Remove(car);
                        Console.WriteLine($"Time to sell the {car}!");
                    }
                }
                else if (currCmd == "Refuel")
                {
                    int fuel = int.Parse(cmdArgs[2]);
                    int initialValue = cars[car][1];
                    cars[car][1] += fuel;

                    if (cars[car][1] > 75)
                    {
                        fuel = 75 - initialValue;
                        cars[car][1] = 75;
                    }

                    Console.WriteLine($"{car} refueled with {fuel} liters");
                }
                else if (currCmd == "Revert")
                {
                    int km = int.Parse(cmdArgs[2]);

                    cars[car][0] -= km;

                    if (cars[car][0] < 10_000)
                    {
                        cars[car][0] = 10000;
                        continue;
                    }

                    Console.WriteLine($"{car} mileage decreased by {km} kilometers");
                }
            }

            foreach ((string car, int[] milageFuel) in cars)
            {
                Console.WriteLine($"{car} -> Mileage: {milageFuel[0]} kms, Fuel in the tank: {milageFuel[1]} lt.");
            }
        }
    }
}
