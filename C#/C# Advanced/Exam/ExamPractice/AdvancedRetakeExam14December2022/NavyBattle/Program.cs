int size = int.Parse(Console.ReadLine());
char[,] battlefield = new char[size, size];

int currRow = 0;
int currCol = 0;
int battleCruisers = 3;
int totalMinesHit = 0;


for (int row = 0; row < size; row++)
{
    string rowData = Console.ReadLine();
    for (int col = 0; col < size; col++)
    {
        if (rowData[col] == 'S')
        {
            currRow = row;
            currCol = col;
            battlefield[row, col] = '-';
            continue;
        }

        battlefield[row, col] = rowData[col];
    }
}

while (true)
{
    string direction = Console.ReadLine();

    MoveSubmarine(direction);
}

void MoveSubmarine(string direction)
{
    switch (direction)
    {
        case "up":
            currRow--;
            CheckCurrentPosition(currRow, currCol);
            break;

        case "right":
            currCol++;
            CheckCurrentPosition(currRow, currCol);
            break;

        case "down":
            currRow++;
            CheckCurrentPosition(currRow, currCol);
            break;

        case "left":
            currCol--;
            CheckCurrentPosition(currRow, currCol);
            break;
    }
}

void CheckCurrentPosition(int row, int col)
{
    switch (battlefield[row, col])
    {
        case '-':
            //all good
        break;

        case '*':
            totalMinesHit++;
            if (totalMinesHit == 3)
            {
                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{row}, {col}]!");
                PrintBattleField();
                Environment.Exit(0);
            }

            battlefield[row, col] = '-';
            break;

        case 'C':
            battleCruisers--;
            battlefield[row, col] = '-';

            if (battleCruisers == 0)
            {
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                PrintBattleField();
                Environment.Exit(0);
            }
            break;
    }
}

void PrintBattleField()
{
    battlefield[currRow, currCol] = 'S';

    for (int r = 0; r < size; r++)
    {
        for (int c = 0; c < size; c++)
        {
            Console.Write($"{battlefield[r, c]}");
        }

        Console.WriteLine();
    }
}