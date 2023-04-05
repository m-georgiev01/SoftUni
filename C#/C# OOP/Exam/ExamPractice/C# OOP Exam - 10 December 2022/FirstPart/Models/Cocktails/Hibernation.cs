namespace ChristmasPastryShop.Models.Cocktails
{
    public class Hibernation : Cocktail
    {
        private const double HibernationPrice = 10.5;

        public Hibernation(string cocktailName, string size) 
            : base(cocktailName, size, HibernationPrice)
        {
        }
    }
}
