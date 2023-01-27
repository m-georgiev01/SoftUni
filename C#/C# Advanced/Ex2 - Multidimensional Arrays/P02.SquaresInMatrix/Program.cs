int[] matrixSizes = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int rows = matrixSizes[0];
int cols = matrixSizes[1];

string[,] matrix = new string[rows, cols];

for (int row = 0; row < rows; row++)
{
    string[] data = Console.ReadLine().Split();
    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = data[col];
    }
}

int count = 0;

for (int row = 0; row < rows - 1; row++)
{
    for (int col = 0; col < cols - 1; col++)
    {
        string firstElement = matrix[row, col];
        string secondElement = matrix[row, col + 1];
        string thirdElement = matrix[row + 1, col + 1];
        string forthElement = matrix[row + 1, col];

        if (firstElement == secondElement &&
            secondElement == thirdElement &&
            firstElement == forthElement)
        {
            count++;
        }
    }
}

Console.WriteLine(count);
