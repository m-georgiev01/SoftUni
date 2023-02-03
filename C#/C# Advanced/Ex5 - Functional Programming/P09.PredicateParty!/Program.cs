List<string> names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string input;
while ((input = Console.ReadLine()) != "Party!")
{
    var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string currCmd = tokens[0];
    string criteria = tokens[1];
    string value = tokens[2];

    if (currCmd == "Remove")
    {
        names.RemoveAll(GetPredicate(criteria, value));
    }
    else if (currCmd == "Double")
    {
        List<string> namesToDouble = names.FindAll(GetPredicate(criteria, value));
        foreach (var name in namesToDouble)
        {
            int index = names.FindIndex(n => n == name);

            names.Insert(index, name);
        }
    }
}

if (names.Any())
{
    Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
}
else
{
    Console.WriteLine("Nobody is going to the party!");
}

Predicate<string> GetPredicate(string criteria, string value)
{
    if (criteria == "StartsWith")
    {
        return name => name.StartsWith(value);
    }
    else if (criteria == "EndsWith")
    {
        return name => name.EndsWith(value);
    }
    else if (criteria == "Length")
    {
        return name => name.Length == int.Parse(value);
    }

    return default;
}