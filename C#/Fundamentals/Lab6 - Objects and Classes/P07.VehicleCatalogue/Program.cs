using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split('/');
                string type = cmdArgs[0];
                string brand = cmdArgs[1];
                string model = cmdArgs[2];
                int value = int.Parse(cmdArgs[3]);

                if (type == "Car")
                {
                    var car = new Car(brand, model, value);
                    catalog.cars.Add(car);
                }
                else if (type == "Truck")
                {
                    var truck = new Truck(brand, model, value);
                    catalog.trucks.Add(truck);
                }                
            }

            if (catalog.cars.Count > 0)
            {
                Console.WriteLine("Cars:");

            }
            foreach (var car in catalog.cars.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }

            if (catalog.trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
            }
            foreach (var truck in catalog.trucks.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }

    class Truck 
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }
    }

    class Catalog
    {
        public List<Truck> trucks;
        public List<Car> cars;

        public Catalog()
        {
            trucks = new List<Truck>();
            cars = new List<Car>();
        }
    }
}
