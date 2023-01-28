Dictionary<double, int> dictionary = new();

double[] nums = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .ToArray();

foreach (var n in nums)
{
    if (!dictionary.ContainsKey(n))
    {
        dictionary.Add(n, 0);
    }

    dictionary[n]++;
}

foreach (var (key, value) in dictionary)
{
    Console.WriteLine($"{key} - {value} times");
}