Queue<int> cups = new(
    Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
    );

Stack<int> bottles = new(
    Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
);

int wastedLittersOfWater = 0;
int lastCupValue = 0;

while (cups.Any())
{
    int currentCup = cups.Peek();
    int currentBottle = bottles.Pop();

    if (lastCupValue != 0)
    {
        currentCup = lastCupValue;
    }

    if (currentBottle >= currentCup )
    {
        wastedLittersOfWater += currentBottle - currentCup;
        lastCupValue = 0;
        cups.Dequeue();
    }
    else
    {
        lastCupValue = currentCup - currentBottle;
    }

    if (!bottles.Any())
    {
        Console.WriteLine($"Cups: {string.Join(" ", cups)}");
        break;
    }
}

if (bottles.Any())
{
    Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
}

Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");