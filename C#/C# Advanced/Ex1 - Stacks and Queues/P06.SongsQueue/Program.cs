var songsQueue = new Queue<string>(Console.ReadLine().Split(", "));

while (songsQueue.Any())
{
    string command = Console.ReadLine();
    string currCmd = command.Substring(0, 4);

    if (currCmd == "Play")
    {
        songsQueue.Dequeue();
    }
    else if (currCmd == "Add ")
    {
        string song = command.Substring(4);
        if (songsQueue.Contains(song))
        {
            Console.WriteLine($"{song} is already contained!");
            continue;
        }

        songsQueue.Enqueue(song);
    }
    else if (currCmd == "Show")
    {
        Console.WriteLine(string.Join(", ", songsQueue));
    }
}

Console.WriteLine("No more songs!");