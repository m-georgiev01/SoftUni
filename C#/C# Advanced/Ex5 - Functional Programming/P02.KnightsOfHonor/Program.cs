Action<string[]> printNamesWithTitle = names =>
{
    Console.WriteLine(string.Join(Environment.NewLine, names.Select(x => $"Sir {x}")));
};

string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

printNamesWithTitle(names);