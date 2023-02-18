//name -> value, countMade
Dictionary<string, int[]> healingItems = new()
{
    { "Patch", new[] { 30, 0 } },
    { "Bandage", new[] { 40, 0 } },
    { "MedKit", new[] { 100, 0 } }
};

Queue<int> textiles = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Stack<int> medicaments = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

while (textiles.Any() && medicaments.Any())
{
    int currValue = textiles.Peek() + medicaments.Peek();
    var healingItemWithCurrSum = healingItems.FirstOrDefault(i => i.Value[0] == currValue);

    if (healingItemWithCurrSum.Key != null)
    {
        healingItems[healingItemWithCurrSum.Key][1]++;
        textiles.Dequeue();
        medicaments.Pop();
        continue;
    }

    if (currValue > 100)
    {
        healingItems["MedKit"][1]++;
        textiles.Dequeue();
        medicaments.Pop();

        currValue -= 100;
        medicaments.Push(medicaments.Pop() + currValue);
        continue;
    }

    textiles.Dequeue();
    medicaments.Push(medicaments.Pop() + 10);
}

if (!textiles.Any() && !medicaments.Any())
{
    Console.WriteLine("Textiles and medicaments are both empty.");
    PrintItems();
}
else if (!textiles.Any())
{
    Console.WriteLine("Textiles are empty.");
    PrintItems();
    Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
}
else
{
    Console.WriteLine("Medicaments are empty.");
    PrintItems();
    Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
}



void PrintItems()
{
    var filteredCollection = healingItems
        .Where(i => i.Value[1] > 0)
        .OrderByDescending(i => i.Value[1])
        .ThenBy(i => i.Key);

    foreach (var (name, itemValues) in filteredCollection)
    {
        Console.WriteLine($"{name} - {itemValues[1]}");
    }
}