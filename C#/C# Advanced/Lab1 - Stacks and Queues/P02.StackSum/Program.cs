int[] inputNums = Console.ReadLine()
                  .Split()
                  .Select(int.Parse)
                  .ToArray();

var numbers = new Stack<int> (inputNums);

string command;
while ((command = Console.ReadLine().ToLower()) != "end")
{
    string[] cmdArgs = command.Split();
    string currCmd = cmdArgs[0];
    int firstNum = int.Parse(cmdArgs[1]);

    if (currCmd == "add")
    {
        int secondNum = int.Parse(cmdArgs[2]);
        numbers.Push(firstNum);
        numbers.Push(secondNum);
    }
    else if (currCmd == "remove")
    {
        if (firstNum > numbers.Count )
        {
            continue;
        }

        for (int i = 0; i < firstNum; i++)
        {
            numbers.Pop();
        }
    }
}

Console.WriteLine($"Sum: {numbers.Sum()}");