int[] matrixSizes = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = matrixSizes[0];
int cols = matrixSizes[1];

string[,] matrix = new string[rows, cols];

for (int row = 0; row < rows; row++)
{
    string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = data[col];
    }
}

string cmd;
while ((cmd = Console.ReadLine()) != "END")
{
    var cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (cmdArgs[0] != "swap" || cmdArgs.Length != 5)
    {
        Console.WriteLine("Invalid input!");
        continue;
    }

    //swap row1 col1 row2 col2
    int row1 = int.Parse(cmdArgs[1]);
    int col1 = int.Parse(cmdArgs[2]);
    int row2 = int.Parse(cmdArgs[3]);
    int col2 = int.Parse(cmdArgs[4]);

    if ((row1 >= 0 && row1 < rows) &&
        (col1 >= 0 && col1 < cols) &&
        (row2 >= 0 && row2 < rows) &&
        (col2 >= 0 && col2 < cols))
    {
        (matrix[row1,col1], matrix[row2, col2]) = (matrix[row2, col2], matrix[row1,col1]);

        for (int rol = 0; rol < rows; rol++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write($"{matrix[rol, col]} ");
            }

            Console.WriteLine();
        }
    }
    else
    {
        Console.WriteLine("Invalid input!");
    }
}