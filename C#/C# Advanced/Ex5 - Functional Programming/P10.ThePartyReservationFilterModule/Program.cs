using System.Linq;

Dictionary<string, Predicate<string>> predicates = new();

List<string> names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string input;
while ((input = Console.ReadLine()) != "Print")
{
    var tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
    string currCmd = tokens[0];
    string criteria = tokens[1];
    string value = tokens[2];

    if (currCmd == "Add filter")
    {
        predicates.Add(criteria + value, GetPredicate(criteria, value));
    }
    else if (currCmd == "Remove filter")
    {
        predicates.Remove(criteria + value);
    }
}

foreach (var (_, match) in predicates)
{
    names.RemoveAll(match);
}

Console.WriteLine(string.Join(" ", names));


Predicate<string> GetPredicate(string criteria, string value)
{
    if (criteria == "Starts with")
    {
        return name => name.StartsWith(value);
    }

    if (criteria == "Ends with")
    {
        return name => name.EndsWith(value);
    }

    if (criteria == "Length")
    {
        return name => name.Length == int.Parse(value);
    }

    if (criteria == "Contains")
    {
        return name => name.Contains(value);
    }

    return default;
}