using System;
using System.Linq;
using System.Text;
using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(booths.Models.Count + 1, capacity);
            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, booth.BoothId, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != nameof(Gingerbread) &&
                delicacyTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            if (this.booths.Models.Any(b => b.DelicacyMenu.Models.Any(dm => dm.Name == delicacyName)))
            {
                return string
                    .Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            IDelicacy delicacy = null;
            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == nameof(Stolen))
            {
                delicacy = new Stolen(delicacyName);
            }

            IBooth currBooth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            currBooth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != nameof(Hibernation) &&
                cocktailTypeName != nameof(MulledWine))
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" &&
                size != "Middle" &&
                size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (booths.Models.Any(b => b.CocktailMenu.Models.Any(cm => cm.Name == cocktailName && cm.Size == size)))
            {
                return string
                    .Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            ICocktail cocktail = null;
            if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else if (cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }

            IBooth currBooth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);


            currBooth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            var booth = booths.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (booth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();

            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople); ;
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderTokens = order.Split('/', StringSplitOptions.RemoveEmptyEntries);
            string itemTypeName = orderTokens[0];
            string itemName = orderTokens[1];
            int pieces = int.Parse(orderTokens[2]);
            string size = string.Empty;

            IBooth currBooth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (!IsValidItem(itemTypeName))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (!currBooth.CocktailMenu.Models.Any(m => m.Name == itemName) &&
                !currBooth.DelicacyMenu.Models.Any(m => m.Name == itemName))
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            if (IsICoctail(itemTypeName))
            {
                size = orderTokens[3];

                ICocktail desiredCocktail = currBooth
                    .CocktailMenu.Models
                    .FirstOrDefault(m => m.GetType().Name == itemTypeName && m.Name == itemName && m.Size == size);

                if (desiredCocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }

                currBooth.UpdateCurrentBill(desiredCocktail.Price * pieces);
            }
            else
            {
                IDelicacy desiredDelicacy = currBooth
                    .DelicacyMenu.Models
                    .FirstOrDefault(m => m.GetType().Name == itemTypeName && m.Name == itemName);

                if (desiredDelicacy == null)
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemName);
                }

                currBooth.UpdateCurrentBill(desiredDelicacy.Price * pieces);
            }

            return string.Format(OutputMessages.SuccessfullyOrdered, boothId, pieces, itemName); ;
        }

        public string LeaveBooth(int boothId)
        {
            IBooth currBooth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Bill {currBooth.CurrentBill:f2} lv");

            currBooth.Charge();
            currBooth.ChangeStatus();

            sb.AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().TrimEnd();
        }

        public string BoothReport(int boothId)
        {
            IBooth currBooth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            return currBooth.ToString().TrimEnd();
        }

        private bool IsICoctail(string itemTypeName)
        {
            return itemTypeName == nameof(Hibernation) ||
                   itemTypeName == nameof(MulledWine);
        }

        private bool IsValidItem(string itemTypeName)
        {
            return itemTypeName == nameof(Hibernation) ||
                   itemTypeName == nameof(MulledWine) ||
                   itemTypeName == nameof(Gingerbread) ||
                   itemTypeName == nameof(Stolen);
        }
    }
}
