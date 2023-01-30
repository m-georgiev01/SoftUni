HashSet<int> firstSet = new();
HashSet<int> secondSet = new();

int[] sizes = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

for (int i = 0; i < sizes[0]; i++)
{
    firstSet.Add(int.Parse(Console.ReadLine()));
}

for (int j = 0; j < sizes[1]; j++)
{
    secondSet.Add(int.Parse(Console.ReadLine()));
}

firstSet.IntersectWith(secondSet);

Console.WriteLine(string.Join(" ", firstSet));