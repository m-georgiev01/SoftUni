int[] tokens = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] nums = Enumerable.Range(tokens[0], tokens[1] - tokens[0] + 1).ToArray();

string command = Console.ReadLine();

Predicate<int> match = number =>
{
    if (command == "odd")
    {
        return number % 2 != 0;
    }

    return number % 2 == 0;
};

foreach (var num in nums)
{
    if (match(num))
    {
        Console.Write($"{num} ");
    }
}