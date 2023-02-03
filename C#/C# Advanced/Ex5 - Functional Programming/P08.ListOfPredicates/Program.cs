List<Predicate<int>> matches = new();

int count = int.Parse(Console.ReadLine());
int[] nums = Enumerable.Range(1, count).ToArray();

HashSet<int> dividers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToHashSet();

foreach (var divider in dividers)
{
    matches.Add(number => number % divider == 0);
}

foreach (var num in nums)
{
    bool isDivisibleByAll = true;

    foreach (var match in matches)
    {
        if (!match(num))
        {
            isDivisibleByAll = false;
        }
    }

    if (isDivisibleByAll)
    {
        Console.Write($"{num} ");
    }
}