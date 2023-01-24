int[] tokens = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int numDequeue = tokens[1];
int lookFor = tokens[2];

int[] numbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

var queue = new Queue<int>(numbers);

for (int i = 0; i < numDequeue; i++)
{
    queue.Dequeue();
}

if (queue.Contains(lookFor))
{
    Console.WriteLine("true");
}
else
{
    if (queue.Any())
    {
        Console.WriteLine(queue.Min());
    }
    else
    {
        Console.WriteLine(0);
    }

}