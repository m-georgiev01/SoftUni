namespace P06.SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance{ get; set; }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0;
        }

        public void Drive(int amountOfKm)
        {
            double fuelNeeded = amountOfKm * FuelConsumptionPerKilometer;

            if (FuelAmount - fuelNeeded >= 0)
            {
                FuelAmount -= fuelNeeded;
                TravelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:F2} {TravelledDistance}";
        }
    }
}
