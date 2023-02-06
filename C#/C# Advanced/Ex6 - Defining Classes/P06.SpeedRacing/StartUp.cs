namespace P06.SpeedRacing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsumptionPer1km = double.Parse(tokens[2]);

                Car c = new(model, fuelAmount, fuelConsumptionPer1km);
                cars.Add(c.Model, c);
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] tokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = tokens[1];
                int amountOfKm = int.Parse(tokens[2]);

                cars[carModel].Drive(amountOfKm);
            }

            foreach (var (_, car) in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
