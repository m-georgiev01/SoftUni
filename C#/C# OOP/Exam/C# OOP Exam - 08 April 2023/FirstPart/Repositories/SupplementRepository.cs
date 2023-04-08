using System.Collections.Generic;
using System.Linq;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> supplements;

        public SupplementRepository()
        {
            supplements = new List<ISupplement>();
        }

        public IReadOnlyCollection<ISupplement> Models()
            => supplements.AsReadOnly();

        public void AddNew(ISupplement model)
            => supplements.Add(model);

        public bool RemoveByName(string typeName)
        {
            foreach (ISupplement supplement in supplements)
            {
                if (supplement.GetType().Name == typeName)
                {
                    return supplements.Remove(supplement);
                }
            }

            return false;
        }

        public ISupplement FindByStandard(int interfaceStandard)
            => supplements.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);
    }
}
