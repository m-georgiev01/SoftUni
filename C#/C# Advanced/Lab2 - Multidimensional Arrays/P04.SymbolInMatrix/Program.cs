int size = int.Parse(Console.ReadLine());


char[,] matrix = new char[size, size];

for (int row = 0; row < size; row++)
{
    string data = Console.ReadLine();
    for (int col = 0; col < size; col++)
    {
        matrix[row, col] = data[col];
    }
}

char symbol = char.Parse(Console.ReadLine());
bool isInMatrix = false;

for (int row = 0; row < size; row++)
{
    for (int col = 0; col < size; col++)
    {
        if (symbol == matrix[row, col])
        {
            isInMatrix = true;
            Console.WriteLine($"({row}, {col})");
            Environment.Exit(0);
        }
    }
}

if (!isInMatrix)
{
    Console.WriteLine($"{symbol} does not occur in the matrix ");
}