using System.Security.Cryptography.X509Certificates;

int size = int.Parse(Console.ReadLine());

if (size == 0)
{
    Console.WriteLine("Alive cells: 0");
    Console.WriteLine("Sum: 0");
    Environment.Exit(0);
}

int[,] matrix = new int[size, size];

for (int row = 0; row < size; row++)
{
    int[] data = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
    for (int col = 0; col < size; col++)
    {
        matrix[row, col] = data[col];
    }
}

string[] coordinatsBombs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

for (int i = 0; i < coordinatsBombs.Length; i++)
{
    int currRow = int.Parse(coordinatsBombs[i][0].ToString());
    int currCol = int.Parse(coordinatsBombs[i][2].ToString());

    //Top-left
    if (IsCoordinatesValid(currRow - 1, currCol -1))
    {
        matrix[currRow - 1, currCol - 1] -= matrix[currRow, currCol];
    }

    //Top-mid
    if (IsCoordinatesValid(currRow - 1, currCol))
    {
        matrix[currRow - 1, currCol] -= matrix[currRow, currCol];
    }

    //Top-right
    if (IsCoordinatesValid(currRow - 1, currCol + 1))
    {
        matrix[currRow - 1, currCol + 1] -= matrix[currRow, currCol];
    }

    //Mid-left
    if (IsCoordinatesValid(currRow, currCol - 1))
    {
        matrix[currRow, currCol - 1] -= matrix[currRow, currCol];
    }

    //Mid-right
    if (IsCoordinatesValid(currRow, currCol + 1))
    {
        matrix[currRow, currCol + 1] -= matrix[currRow, currCol];
    }

    //Bot-left
    if (IsCoordinatesValid(currRow + 1, currCol - 1))
    {
        matrix[currRow + 1, currCol - 1] -= matrix[currRow, currCol];
    }

    //Bot-mid
    if (IsCoordinatesValid(currRow + 1, currCol))
    {
        matrix[currRow + 1, currCol] -= matrix[currRow, currCol];
    }

    //Bot-right
    if (IsCoordinatesValid(currRow + 1, currCol + 1))
    {
        matrix[currRow + 1, currCol + 1] -= matrix[currRow, currCol];
    }

    matrix[currRow, currCol] = 0;
}

int sum = matrix.Cast<int>().Where(x => x > 0).Sum();
int aliveCellsCount = matrix.Cast<int>().Count(x => x > 0);

Console.WriteLine($"Alive cells: {aliveCellsCount}");
Console.WriteLine($"Sum: {sum}");

for (int r = 0; r < size; r++)
{
    for (int c = 0; c < size; c++)
    {
        Console.Write($"{matrix[r, c]} ");
    }

    Console.WriteLine();
}

bool IsCoordinatesValid(int row, int col)
{
    bool isValid = row >= 0 && row < size &&
                   col >= 0 && col < size &&
                   matrix[row,col] > 0;

    return isValid;
}