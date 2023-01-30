HashSet<string> set = new();

int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string[] compounds = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    foreach (var c in compounds)
    {
        set.Add(c);
    }
}

Console.WriteLine(string.Join(" ", set.OrderBy(x => x)));