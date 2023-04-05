using System.Collections.Generic;
using System.Linq;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;

        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models
            => planets.AsReadOnly();

        public IPlanet FindByName(string name)
            => Models.FirstOrDefault(p => p.Name == name);

        public void AddItem(IPlanet model)
            => planets.Add(model);

        public bool RemoveItem(string name)
        {
            IPlanet planet = this.FindByName(name);

            return planets.Remove(planet);
        }
    }
}
