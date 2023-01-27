int rows = int.Parse(Console.ReadLine());

double[][] jaggedArr = new double[rows][];

for (int row = 0; row < rows; row++)
{
    int[] data = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
    jaggedArr[row] = new double[data.Length];

    for (int col = 0; col < data.Length; col++)
    {
        jaggedArr[row][col] = data[col];
    }
}

for (int r = 0; r < rows - 1; r++)
{
    if (jaggedArr[r].Length == jaggedArr[r + 1].Length)
    {
        jaggedArr[r] = jaggedArr[r].Select(x => x * 2).ToArray();
        jaggedArr[r + 1] = jaggedArr[r + 1].Select(x => x * 2).ToArray();
    }
    else
    {
        jaggedArr[r] = jaggedArr[r].Select(x => x / 2).ToArray();
        jaggedArr[r + 1] = jaggedArr[r + 1].Select(x => x / 2).ToArray();
    }
}

string cmd;
while ((cmd = Console.ReadLine()) != "End")
{
    var cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string currCmd = cmdArgs[0];
    int row = int.Parse(cmdArgs[1]);
    int col = int.Parse(cmdArgs[2]);
    double value = double.Parse(cmdArgs[3]);

    if ((row >= 0 && row < rows) &&
        (col >= 0) && col < jaggedArr[row].Length)
    {
        if (currCmd == "Add")
        {
            jaggedArr[row][col] += value;
        }
        else if (currCmd == "Subtract")
        {
            jaggedArr[row][col] -= value;
        }
    }
}

for (int r = 0; r < rows; r++)
{
    Console.WriteLine(string.Join(" ", jaggedArr[r]));
}