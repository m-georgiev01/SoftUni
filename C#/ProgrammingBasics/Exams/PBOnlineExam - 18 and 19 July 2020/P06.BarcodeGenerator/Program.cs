using System;

namespace P06.BarcodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            int fdStart = int.Parse(start.ToString()[0].ToString());
            int fdEnd = int.Parse(end.ToString()[0].ToString());

            int sdStart = int.Parse(start.ToString()[1].ToString());
            int sdEnd = int.Parse(end.ToString()[1].ToString());

            int tdStart = int.Parse(start.ToString()[2].ToString());
            int tdEnd = int.Parse(end.ToString()[2].ToString());

            int fthdStart = int.Parse(start.ToString()[3].ToString());
            int fthdEnd = int.Parse(end.ToString()[3].ToString());


            for (int i = fdStart; i <= fdEnd; i++)
            {
                for (int j = sdStart; j <= sdEnd; j++)
                {
                    for (int k = tdStart; k <= tdEnd; k++)
                    {
                        for (int l = fthdStart; l <= fthdEnd; l++)
                        {
                            if (i % 2 == 0 || j % 2 == 0 || k % 2 == 0 || l % 2 == 0)
                            {
                                continue;
                            }
                            else
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
