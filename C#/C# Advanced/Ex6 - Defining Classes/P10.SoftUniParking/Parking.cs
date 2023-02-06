namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            cars = new();
            this.capacity = capacity;
        }

        public int Count => cars.Count;

        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count + 1 > capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car.RegistrationNumber, car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar (string registrationNumber)
        {
            if (!cars.ContainsKey(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(registrationNumber);

            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            return cars[registrationNumber];
        }

        public void RemoveSetOfRegistrationNumber (List<string> registrationNumbers)
        {
            foreach (var (regNum, car) in cars)
            {
                foreach (var wantedRegNum in registrationNumbers)
                {
                    if (regNum == wantedRegNum)
                    {
                        cars.Remove(regNum);
                        break;
                    }
                }
            }
        }
    }
}
