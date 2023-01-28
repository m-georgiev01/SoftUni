int[] nums = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .OrderByDescending(x => x)
    .ToArray();

int count = nums.Length >= 3 ? 3 : nums.Length;

Console.WriteLine(string.Join(" ", nums.Take(count)));