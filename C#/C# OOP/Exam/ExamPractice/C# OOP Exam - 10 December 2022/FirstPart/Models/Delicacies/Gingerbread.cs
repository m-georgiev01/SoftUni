namespace ChristmasPastryShop.Models.Delicacies
{
    public class Gingerbread : Delicacy
    {
        private const double GignerbreadPrice = 4;

        public Gingerbread(string delicacyName) 
            : base(delicacyName, GignerbreadPrice)
        {
        }
    }
}
