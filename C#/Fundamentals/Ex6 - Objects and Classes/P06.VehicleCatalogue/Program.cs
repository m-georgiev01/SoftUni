using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P06.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();
                string typeVehicle = cmdArgs[0];
                string model = cmdArgs[1];
                string color = cmdArgs[2];
                int horsePower = int.Parse(cmdArgs[3]);

                Vehicle vehicle = typeVehicle == "car" ? (Vehicle)new Car(model, color, horsePower) : (Vehicle)new Truck(model, color, horsePower);
                vehicles.Add(vehicle);
            }

            string modelCar;
            while ((modelCar = Console.ReadLine()) != "Close the Catalogue")
            {
                Vehicle veh = vehicles.FirstOrDefault(x => x.Model == modelCar);
                Console.WriteLine(veh);
            }

            double avgCarsHp = 0;
            double avgTrucksHp = 0;
            if (vehicles.Where(x => x.GetType().Name == "Car").ToList().Count > 0)
            {
                avgCarsHp = vehicles.Where(x => x.GetType().Name == "Car").Select(x => x.HorsePower).Average();
            }

            if (vehicles.Where(x => x.GetType().Name == "Truck").ToList().Count > 0)
            {
                avgTrucksHp = vehicles.Where(x => x.GetType().Name == "Truck").Select(x => x.HorsePower).Average();
            }

            Console.WriteLine($"Cars have average horsepower of: {avgCarsHp:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {avgTrucksHp:f2}.");

        }
    }

    class Vehicle
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public Vehicle(string model, string color, int horsePower)
        {
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Color: {this.Color}");
            sb.AppendLine($"Horsepower: {this.HorsePower}");

            return sb.ToString().Trim();
        }
    }

    class Car : Vehicle
    {
        public Car(string model, string color, int horsePower)
            : base(model, color, horsePower)
        {
        }
    }

    class Truck : Vehicle
    {
        public Truck(string model, string color, int horsePower)
            : base(model, color, horsePower)
        {
        }
    }
}
