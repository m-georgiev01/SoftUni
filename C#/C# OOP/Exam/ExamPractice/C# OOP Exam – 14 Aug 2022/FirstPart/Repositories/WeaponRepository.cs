using System.Collections.Generic;
using System.Linq;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models
            => weapons.AsReadOnly();

        public IWeapon FindByName(string name)
            => Models.FirstOrDefault(w => w.GetType().Name == name);

        public void AddItem(IWeapon model)
            => weapons.Add(model);


        public bool RemoveItem(string name)
        {
            IWeapon weapon = this.FindByName(name);

            return weapons.Remove(weapon);
        }
    }
}
