using PizzaCalories.Models;

string[] pizzaArgs = Console.ReadLine().Split(" ");

Pizza pizza = null;

try
{
    pizza = new Pizza(pizzaArgs[1]);

    var doughArgs = Console.ReadLine().Split(" ");
    Dough dough = new(doughArgs[1], doughArgs[2], double.Parse(doughArgs[3]));

    pizza.Dough = dough;

    string input;
    while ((input = Console.ReadLine()) != "END")
    {
        var toppingArgs = input.Split(" ");
        Topping topping = new(toppingArgs[1], double.Parse(toppingArgs[2]));

        pizza.AddTopping(topping);
    }
}
catch (ArgumentException ae)
{
    Console.WriteLine(ae.Message);
    Environment.Exit(0);
}

Console.WriteLine(pizza);