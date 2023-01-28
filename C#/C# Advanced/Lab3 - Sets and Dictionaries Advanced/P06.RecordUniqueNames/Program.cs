HashSet<string> set = new();

int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    set.Add(input);
}

foreach (var name in set)
{
    Console.WriteLine(name);
}
