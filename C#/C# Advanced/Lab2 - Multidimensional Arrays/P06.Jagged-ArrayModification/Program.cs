int size = int.Parse(Console.ReadLine());
int[][] matrix = new int[size][];

for (int row = 0; row < size; row++)
{
    int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

    matrix[row] = new int[size];

    for (int col = 0; col < size; col++)
    {
        matrix[row][col] = numbers[col];
    }
}

string cmd;
while ((cmd = Console.ReadLine()) != "END")
{
    string[] cmdArgs = cmd.Split();
    string currCmd = cmdArgs[0];
    int row = int.Parse(cmdArgs[1]);
    int col = int.Parse(cmdArgs[2]);
    int value = int.Parse(cmdArgs[3]);

    if (row < 0 || row >= size ||
        col < 0 || col >= size)
    {
        Console.WriteLine("Invalid coordinates");
        continue;
    }

    if (currCmd == "Add")
    {
        matrix[row][col] += value;
    }
    else if (currCmd == "Subtract")
    {
        matrix[row][col] -= value;
    }
}

for (int i = 0; i < size; i++)
{
    Console.WriteLine(string.Join(" ", matrix[i]));
}