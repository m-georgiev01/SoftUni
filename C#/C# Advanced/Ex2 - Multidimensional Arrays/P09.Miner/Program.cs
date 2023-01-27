int size = int.Parse(Console.ReadLine());

char[,] matrix = new char[size, size];

string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
int currRow = 0;
int currCol = 0;

for (int row = 0; row < size; row++)
{
    char[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
    for (int col = 0; col < size; col++)
    {
        if (data[col] == 's')
        {
            currRow = row;
            currCol = col;
        }
        matrix[row, col] = data[col];
    }
}

foreach (var currCmd in commands)
{
    if (currCmd == "left")
    {
        if (IsCellValid(currRow, currCol - 1))
        {
            CheckEnding(currRow, currCol - 1);
            currCol--;
        }
    }
    else if (currCmd == "right")
    {
        if (IsCellValid(currRow, currCol + 1))
        {
            CheckEnding(currRow, currCol + 1);
            currCol++;
        }
    }
    else if (currCmd == "up")
    {
        if (IsCellValid(currRow - 1, currCol))
        {
            CheckEnding(currRow - 1, currCol);
            currRow--;
        }
    }
    else if (currCmd == "down")
    {
        if (IsCellValid(currRow + 1, currCol))
        {
            CheckEnding(currRow + 1, currCol);
            currRow++;
        }
    }
}

Console.WriteLine($"{matrix.Cast<char>().Count(x => x == 'c')} coals left. ({currRow}, {currCol})");

bool IsCellValid(int row, int col)
{
    return row >= 0 &&
           row < size &&
           col >= 0 &&
           col < size;
}

void CheckEnding(int row, int col)
{
    if (matrix[row, col] == 'c')
    {
        matrix[row, col] = '*';
        int i = matrix.Cast<char>().Count(x => x == 'c');
        if (matrix.Cast<char>().Count(x => x == 'c') == 0)
        {
            Console.WriteLine($"You collected all coals! ({row}, {col})");
            Environment.Exit(0);
        }
    }
    else if (matrix[row, col] == 'e')
    {
        Console.WriteLine($"Game over! ({row}, {col})");
        Environment.Exit(0);
    }
}