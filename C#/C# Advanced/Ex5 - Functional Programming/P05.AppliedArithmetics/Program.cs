Func<int[], string, int[]> calculate = (nums, command) =>
{
    int[] result = new int[nums.Length];

    if (command == "add")
    {
        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = nums[i] + 1;
        }
    }
    else if (command == "multiply")
    {
        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = nums[i] * 2;
        }
    }
    else if (command == "subtract")
    {
        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = nums[i] - 1;
        }
    }

    return result;
};

int[] nums = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

string cmd;
while ((cmd = Console.ReadLine()) != "end")
{
    if (cmd == "print")
    {
        Console.WriteLine(string.Join(" ", nums));
        continue;
    }

    nums = calculate(nums, cmd);
}