int[] matrixSizes = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = matrixSizes[0];
int cols = matrixSizes[1];

string[,] matrix = new string[rows, cols];

string snake = Console.ReadLine();
int index = 0;

for (int row = 0; row < rows; row++)
{
    if (row % 2 == 0)
    {
        for (int col = 0; col < cols; col++)
        {
            if (index == snake.Length)
            {
                index = 0;
            }
            matrix[row, col] = snake[index].ToString();
            index++;
        }
    }
    else
    {
        for (int col = cols - 1; col >= 0; col--)
        {
            if (index == snake.Length)
            {
                index = 0;
            }
            matrix[row, col] = snake[index].ToString();
            index++;
        }
    }
    
}

for (int r = 0; r < rows; r++)
{
    for (int c = 0; c < cols; c++)
    {
        Console.Write($"{matrix[r, c]}");
    }

    Console.WriteLine();
}