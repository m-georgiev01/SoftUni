Stack<int> miligramsCoffe = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Queue<int> energyDrinks = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

int caffeineTaken = 0;

while (miligramsCoffe.Any() && energyDrinks.Any())
{
    int currCaffeine = miligramsCoffe.Pop() * energyDrinks.Peek();

    if (currCaffeine + caffeineTaken <= 300)
    {
        energyDrinks.Dequeue();
        caffeineTaken += currCaffeine;
    }
    else
    {
        energyDrinks.Enqueue(energyDrinks.Peek());
        energyDrinks.Dequeue();

        if (caffeineTaken - 30 < 0)
        {
            caffeineTaken = 0;
            continue;
        }

        caffeineTaken -= 30;
    }
}

if (energyDrinks.Any())
{
    Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
}
else
{
    Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
}

Console.WriteLine($"Stamat is going to sleep with {caffeineTaken} mg caffeine.");