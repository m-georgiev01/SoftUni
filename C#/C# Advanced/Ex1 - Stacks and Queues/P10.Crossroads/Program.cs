Queue<string> cars = new();

int greenLightDuration = int.Parse(Console.ReadLine());
int freeWindowDuration = int.Parse(Console.ReadLine());
int totalCarsPassed = 0;

string cmd;
while ((cmd = Console.ReadLine()) != "END")
{
    if (cmd == "green")
    {
        int time = greenLightDuration;
        while (time > 0 && cars.Any())
        {

            string currentCar = cars.Dequeue();
            int carLength = currentCar.Length;

            time -= carLength;

            if (time >= 0)
            {
                totalCarsPassed++;
            }
            else
            {
                if (time + freeWindowDuration < 0)
                {
                    int hitIndex = carLength - Math.Abs(time + freeWindowDuration);
                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{currentCar} was hit at {currentCar[hitIndex]}.");
                    Environment.Exit(0);
                }

                totalCarsPassed++;
            }
        }
    }
    else
    {
        cars.Enqueue(cmd);
    }
}
Console.WriteLine("Everyone is safe.");
Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");