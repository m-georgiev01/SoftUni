HashSet<string> set = new();
int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string username = Console.ReadLine();
    set.Add(username);
}

foreach (var un in set)
{
    Console.WriteLine(un);
}