int foodQuantity = int.Parse(Console.ReadLine());
int[] orders = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

var ordersQueue = new Queue<int>(orders);

if (ordersQueue.Any())
{
    Console.WriteLine(ordersQueue.Max());
}

while (ordersQueue.Any())
{
    int currOrderQuantity = ordersQueue.Peek();
    if (foodQuantity < currOrderQuantity)
    {
        break;
    }

    foodQuantity -= ordersQueue.Dequeue();
}

if (ordersQueue.Any())
{
    Console.WriteLine($"Orders left: {string.Join(' ', ordersQueue)}");
}
else
{
    Console.WriteLine("Orders complete");
}