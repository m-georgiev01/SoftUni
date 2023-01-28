Dictionary<string, List<decimal>> dict = new();

int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string key = tokens[0];
    decimal grade = decimal.Parse(tokens[1]);

    if (!dict.ContainsKey(key))
    {
        dict.Add(key, new List<decimal>());
    }

    dict[key].Add(grade);
}

foreach (var (name, grades) in dict)
{
    Console.WriteLine($"{name} -> {string.Join(" ", grades.Select(x => x.ToString("F2")))} (avg: {grades.Average():F2})");
}