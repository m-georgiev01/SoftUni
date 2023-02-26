using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new Car(10, 10);
            var sportCar = new SportCar(10, 10);
            var famC = new FamilyCar(10, 10);

            Console.WriteLine(car.FuelConsumption);
            Console.WriteLine(sportCar.FuelConsumption);
            Console.WriteLine(famC.FuelConsumption);

            sportCar.Drive(50);
            Console.WriteLine(sportCar.Fuel);
        }
    }
}
