using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IVehicle> vehicles = new();

            string[] carTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            vehicles.Add(new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]), double.Parse(carTokens[3])));

            string[] truckTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            vehicles.Add(new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]), double.Parse(truckTokens[3])));

            string[] busTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            vehicles.Add(new Bus(double.Parse(busTokens[1]), double.Parse(busTokens[2]), double.Parse(busTokens[3])));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = tokens[0];
                string vehicleType = tokens[1];
                double value = double.Parse(tokens[2]);

                IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

                try
                {
                    if (cmdType == "Drive")
                    {
                        Console.WriteLine(vehicle.Drive(value));
                    }
                    else if(cmdType == "Refuel")
                    {
                        vehicle.Refuel(value);
                    }
                    else //drive empty
                    {
                        Console.WriteLine(vehicle.Drive(value, false));
                        
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}