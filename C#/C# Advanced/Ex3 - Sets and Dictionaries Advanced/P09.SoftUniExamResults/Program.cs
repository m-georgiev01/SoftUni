//username, points
Dictionary<string, int> userPoints = new();

//language, count
Dictionary<string, int> languageSubmissions = new();

string input;
while ((input = Console.ReadLine()) != "exam finished")
{
    var tokens = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
    string username = tokens[0];

    if (tokens[1] == "banned")
    {
        if (userPoints.ContainsKey(username))
        {
            userPoints.Remove(username);
        }
        continue;
    }

    string language = tokens[1];
    int points = int.Parse(tokens[2]);

    StoreUserTries(username, points);
    StoreLanguageSubmissions(language);
}

Console.WriteLine("Results:");
foreach (var (username, points) in 
         userPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    Console.WriteLine($"{username} | {points}");
}

Console.WriteLine("Submissions:");
foreach (var (lang, count) in 
         languageSubmissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    Console.WriteLine($"{lang} - {count}");
}

void StoreUserTries(string username, int points)
{
    if (!userPoints.ContainsKey(username))
    {
        userPoints.Add(username, points);
    }

    if (points > userPoints[username])
    {
        userPoints[username] = points;
    }
}

void StoreLanguageSubmissions(string lang)
{
    if (!languageSubmissions.ContainsKey(lang))
    {
        languageSubmissions.Add(lang, 0);
    }

    languageSubmissions[lang]++;
}