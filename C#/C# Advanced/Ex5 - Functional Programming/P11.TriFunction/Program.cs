Func<string, int, bool> filter = (name, sum) => 
    name.Sum(ch => ch) >= sum;

Action<string[], int, Func<string, int, bool>> print = (names, sum, match) =>
{
    foreach (var name in names)
    {
        if (match(name, sum))
        {
            Console.WriteLine(name);
            break;
        }
    }
};

int sum = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

print(names, sum, filter);