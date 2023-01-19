string[] input = Console.ReadLine().Split();
var kids = new Queue<string>(input);

int n = int.Parse(Console.ReadLine());

int turn = 1;
while (kids.Count != 1)
{
    if (turn < n)
    {
        turn++;
        string currKid = kids.Dequeue();
        kids.Enqueue(currKid);
    }
    else
    {
        turn = 1;
        Console.WriteLine($"Removed {kids.Dequeue()}");
    }
}

Console.WriteLine($"Last is {kids.Peek()}");