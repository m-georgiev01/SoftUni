Dictionary<int, int> dict = new();

int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    int currNum = int.Parse(Console.ReadLine());
    if (!dict.ContainsKey(currNum))
    {
        dict.Add(currNum, 0);
    }

    dict[currNum]++;
}

int result = dict.Where(x => x.Value % 2 == 0).Select(x => x.Key).First();

Console.WriteLine(result);