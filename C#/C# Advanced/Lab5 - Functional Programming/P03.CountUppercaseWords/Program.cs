﻿string[] words = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Where(x => char.IsUpper(x[0]))
    .ToArray();

Console.WriteLine(String.Join(Environment.NewLine, words));