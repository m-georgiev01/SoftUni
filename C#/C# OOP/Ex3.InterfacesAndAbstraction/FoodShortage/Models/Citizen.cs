using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models
{
    public class Citizen : IIdentifiable, IBirthdable, IBuyer
    {
        public Citizen(string id, string name, int age, string birthDate)
        {
            Id = id;
            Name = name;
            Age = age;
            BirthDate = birthDate;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string BirthDate { get; private set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
