using System;
using System.Drawing;
using System.Linq;

namespace Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] playingField = new char[size, size];

            int currRow = 0;
            int currCol = 0;
            int points = 0;

            for (int row = 0; row < size; row++)
            {
                string data = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    if (data[col] == 'M')
                    {
                        currRow = row;
                        currCol = col;
                        playingField[row, col] = '-';
                        continue;
                    }

                    playingField[row, col] = data[col];
                }
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                switch (cmd)
                {
                    case "up":
                        if (!IsInsidePlayingField(currRow - 1, currCol, playingField))
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            continue;
                        }

                        currRow--;
                        CheckPosition(ref currRow, ref currCol, ref points, playingField);
                        break;

                    case "right":
                        if (!IsInsidePlayingField(currRow, currCol + 1, playingField))
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            continue;
                        }

                        currCol++;
                        CheckPosition(ref currRow, ref currCol, ref points, playingField);
                        break;

                    case "down":
                        if (!IsInsidePlayingField(currRow + 1, currCol, playingField))
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            continue;
                        }

                        currRow++;
                        CheckPosition(ref currRow, ref currCol,ref points, playingField);
                        break;

                    case "left":
                        if (!IsInsidePlayingField(currRow, currCol - 1, playingField))
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            continue;
                        }

                        currCol--;
                        CheckPosition(ref currRow, ref currCol, ref points, playingField);
                        break;
                }

                if (points >= 25)
                {
                    Console.WriteLine("Yay! The Mole survived another game!");
                    Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
                    break;
                }
            }

            if (points < 25)
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            playingField[currRow, currCol] = 'M';
            PrintMatrix(playingField);
        }

        private static bool IsInsidePlayingField<T>(int currRow, int currCol, T[,] field)
        {
            return currRow >= 0 && currRow < field.GetLength(0) &&
                   currCol >=0 && currCol < field.GetLength(0);
        }

        private static void CheckPosition(ref int currRow,ref int currCol, ref int points, char[,] field)
        {
            if (field[currRow, currCol] == 'S')
            {
                field[currRow, currCol] = '-';
                Tuple<int, int> otherEndTunnel = CoordinatesOf(field, 'S');
                field[otherEndTunnel.Item1, otherEndTunnel.Item2] = '-';
                currRow = otherEndTunnel.Item1;
                currCol = otherEndTunnel.Item2;
                points -= 3;
            }
            else if (char.IsDigit(field[currRow, currCol]))
            {
                points += int.Parse(field[currRow, currCol].ToString());
                field[currRow, currCol] = '-';
            }
        }

        static Tuple<int, int> CoordinatesOf<T>(T[,] matrix, T value)
        {
            for (int x = 0; x < matrix.GetLength(0); ++x)
            {
                for (int y = 0; y < matrix.GetLength(0); ++y)
                {
                    if (matrix[x, y].Equals(value))
                        return Tuple.Create(x, y);
                }
            }

            return default;
        }

        private static void PrintMatrix<T>(T[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(0); c++)
                {
                    Console.Write($"{matrix[r, c]}");
                }
                Console.WriteLine();
            }
        }
    }
}
