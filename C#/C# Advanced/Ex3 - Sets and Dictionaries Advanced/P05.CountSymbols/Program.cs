Dictionary<char, int> dict = new();
string input = Console.ReadLine();

for (int i = 0; i < input.Length; i++)
{
    if (!dict.ContainsKey(input[i]))
    {
        dict.Add(input[i], 0);
    }

    dict[input[i]]++;
}

foreach (var (ch, count) in dict.OrderBy(x => x.Key))
{
    Console.WriteLine($"{ch}: {count} time/s");
}