Dictionary<string, Dictionary<string, HashSet<string>>> vloggers = new();

string input = string.Empty;
while ((input = Console.ReadLine()) != "Statistics")
{
    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = tokens[1];
    string vloggerName = tokens[0];

    if (command == "joined")
    {
        if (!vloggers.ContainsKey(vloggerName))
        {
            vloggers.Add(vloggerName, new Dictionary<string, HashSet<string>>());
            vloggers[vloggerName].Add("followers", new HashSet<string>());
            vloggers[vloggerName].Add("following", new HashSet<string>());
        }
    }
    else if (command == "followed")
    {
        string vloggerToFollow = tokens[2];

        if (vloggers.ContainsKey(vloggerName) &&
            vloggers.ContainsKey(vloggerToFollow) &&
            vloggerName != vloggerToFollow)
        {
            vloggers[vloggerName]["following"].Add(vloggerToFollow);
            vloggers[vloggerToFollow]["followers"].Add(vloggerName);
        }
    }
}

int count = 1;

Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

Dictionary<string, Dictionary<string, HashSet<string>>> orderedVloggers = vloggers
    .OrderByDescending(v => v.Value["followers"].Count)
    .ThenBy(v => v.Value["following"].Count)
    .ToDictionary(v => v.Key, v => v.Value);

foreach (var vlogger in orderedVloggers)
{
    Console.WriteLine(
        $"{count}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

    if (count == 1)
    {
        //Try SortedSet for vloggers 
        List<string> orderedFollowers = vlogger.Value["followers"]
            .OrderBy(f => f)
            .ToList();

        foreach (var follower in orderedFollowers)
        {
            Console.WriteLine($"*  {follower}");
        }
    }

    count++;
}