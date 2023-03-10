using WildFarm.Factories;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Interfaces;

List<IAnimal> animals = new();

IAnimalFactory animalFactory = new AnimalFactory();
IFoodFactory foodFactory = new FoodFactory();

string input;
while ((input = Console.ReadLine()) != "End")
{
    try
    {
        var animalTokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        IAnimal animal = animalFactory.CreateAnimal(animalTokens);
        animals.Add(animal);

        Console.WriteLine(animal.ProduceSound());

        var foodTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        IFood food = foodFactory.CreateFood(foodTokens);

        animal.Eat(food);
    }
    catch (ArgumentException ae)
    {
        Console.WriteLine(ae.Message);
    }
}

foreach (var animal in animals)
{
    Console.WriteLine(animal);
}