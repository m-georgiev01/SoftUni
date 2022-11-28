using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P03.ThePianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pieces = new Dictionary<string, string[]>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] initialPieceArgs = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string piece = initialPieceArgs[0];
                string composer = initialPieceArgs[1];
                string key = initialPieceArgs[2];

                pieces.Add(piece, new string[2] {composer, key});
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = command.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string currCmd = cmdArgs[0];
                string currPiece = cmdArgs[1];

                if (currCmd == "Add")
                {
                    string currComposer = cmdArgs[2];
                    string currKey = cmdArgs[3];

                    if (pieces.ContainsKey(currPiece))
                    {
                        Console.WriteLine($"{currPiece} is already in the collection!");
                        continue;
                    }

                    pieces.Add(currPiece, new string[2] {currComposer, currKey});
                    Console.WriteLine($"{currPiece} by {currComposer} in {currKey} added to the collection!");
                }
                else if (currCmd == "Remove")
                {
                    if (pieces.ContainsKey(currPiece))
                    {
                        pieces.Remove(currPiece);
                        Console.WriteLine($"Successfully removed {currPiece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {currPiece} does not exist in the collection.");
                    }
                }
                else if (currCmd == "ChangeKey")
                {
                    string currKey = cmdArgs[2];

                    if (pieces.ContainsKey(currPiece))
                    {
                        pieces[currPiece][1] = currKey;
                        Console.WriteLine($"Changed the key of {currPiece} to {currKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {currPiece} does not exist in the collection.");
                    }
                }
            }

            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
            }
        }
    }
}
