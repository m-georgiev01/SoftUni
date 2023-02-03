Func<int[], int> findMinInArr = nums => nums.Min();

int[] nums = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Console.WriteLine(findMinInArr(nums));