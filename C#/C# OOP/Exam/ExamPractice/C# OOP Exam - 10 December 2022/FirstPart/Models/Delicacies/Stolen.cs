namespace ChristmasPastryShop.Models.Delicacies
{
    public class Stolen : Delicacy
    {
        private const double StolenPrice = 3.5;

        public Stolen(string delicacyName) 
            : base(delicacyName, StolenPrice)
        {
        }
    }
}
