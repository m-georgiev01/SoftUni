Func<List<int>, Predicate<int>, List<int>> excludeDivisible = (numbers, match) =>
{
    List<int> result = new();

    foreach (var number in numbers)
    {
        if (!match(number))
        {
            result.Add(number);
        }
    }

    return result;
};

List<int> nums = Console.ReadLine()
.Split(" ", StringSplitOptions.RemoveEmptyEntries)
.Select(int.Parse)
.ToList();
 
int divisor = int.Parse(Console.ReadLine());

nums = excludeDivisible(nums, num => num % divisor == 0);
nums.Reverse();

Console.WriteLine(string.Join(" ", nums));