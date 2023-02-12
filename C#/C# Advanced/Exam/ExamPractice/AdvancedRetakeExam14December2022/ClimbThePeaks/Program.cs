using System.Threading.Channels;

Stack<int> foodPortions = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Queue<int> stamina = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

Dictionary<string, int> mountainPeeks = new()
{
    { "Vihren", 80 },
    { "Kutelo", 90 },
    { "Banski Suhodol", 100 },
    { "Polezhan", 60 },
    { "Kamenitza", 70 }
};

Queue<string> climbedPeeks = new();


while (foodPortions.Any())
{
    int daySum = foodPortions.Pop() + stamina.Dequeue();
    var currMountainPeek = mountainPeeks.FirstOrDefault();

    if (daySum >= currMountainPeek.Value)
    {
        climbedPeeks.Enqueue(currMountainPeek.Key);
        mountainPeeks.Remove(currMountainPeek.Key);

        if (!mountainPeeks.Any())
        {
            Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            break;
        }
    }
}

if (mountainPeeks.Any())
{
    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
}

if (climbedPeeks.Any())
{
    Console.WriteLine("Conquered peaks:");
    Console.WriteLine(string.Join(Environment.NewLine, climbedPeeks));
}