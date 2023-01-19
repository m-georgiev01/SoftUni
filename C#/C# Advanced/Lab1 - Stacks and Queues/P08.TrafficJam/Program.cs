int n = int.Parse(Console.ReadLine());
var cars = new Queue<string>();
int count = 0;

string command;
while ((command = Console.ReadLine()) != "end")
{
    if (command == "green")
    {
        for (int i = 0; i < n; i++)
        {
            if (!cars.Any())
            {
                break;
            }
            Console.WriteLine($"{cars.Dequeue()} passed!");
            count++;
        }
    }
    else
    {
        cars.Enqueue(command);
    }
}

Console.WriteLine($"{count} cars passed the crossroads.");