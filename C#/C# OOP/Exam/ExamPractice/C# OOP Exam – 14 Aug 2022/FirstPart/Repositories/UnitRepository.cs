using System.Collections.Generic;
using System.Linq;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> units;

        public UnitRepository()
        {
            units = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models
            => units.AsReadOnly();

        public IMilitaryUnit FindByName(string name)
            => Models.FirstOrDefault(u => u.GetType().Name == name);

        public void AddItem(IMilitaryUnit model) 
            => units.Add(model);


        public bool RemoveItem(string name)
        {
            IMilitaryUnit unit = this.FindByName(name);

            return units.Remove(unit);
        }
    
    }
}
