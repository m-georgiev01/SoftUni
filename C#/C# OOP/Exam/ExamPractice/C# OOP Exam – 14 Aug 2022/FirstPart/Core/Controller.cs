using PlanetWars.Core.Contracts;
using System;
using System.Linq;
using System.Text;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System.Xml.Linq;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private IRepository<IPlanet> planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.Models.Any(p => p.Name == name))
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            IPlanet planet = new Planet(name, budget);
            planets.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            if (!planets.Models.Any(p => p.Name == planetName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName != nameof(AnonymousImpactUnit) &&
                unitTypeName != nameof(SpaceForces) &&
                unitTypeName != nameof(StormTroopers))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            IPlanet planet = planets.FindByName(planetName);
            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            IMilitaryUnit unit = null;
            if (unitTypeName == nameof(AnonymousImpactUnit))
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (!planets.Models.Any(p => p.Name == planetName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IPlanet planet = planets.FindByName(planetName);
            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (weaponTypeName != nameof(BioChemicalWeapon) &&
                weaponTypeName != nameof(NuclearWeapon) &&
                weaponTypeName != nameof(SpaceMissiles))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            IWeapon weapon = null;
            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(SpaceMissiles))
            {
                weapon = new SpaceMissiles(destructionLevel);
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            if (!planets.Models.Any(p => p.Name == planetName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IPlanet planet = planets.FindByName(planetName);
            if (!planet.Army.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.Spend(1.25);
            planet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);


            if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                return AfterWinningTheWar(firstPlanet, secondPlanet, planets);
            }
            else if (secondPlanet.MilitaryPower > firstPlanet.MilitaryPower)
            {
                return AfterWinningTheWar(secondPlanet, firstPlanet, planets);
            }
            else
            {
                if (firstPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon) && 
                                                 !secondPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon))))
                {
                    return AfterWinningTheWar(firstPlanet, secondPlanet, planets);
                }
                else if (!firstPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon) &&
                                                      secondPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon))))
                {
                    return AfterWinningTheWar(secondPlanet, firstPlanet, planets);
                }
                else
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);

                    return OutputMessages.NoWinner;
                }
            }
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            var orderedPlanets = planets.Models.OrderByDescending(p => p.MilitaryPower)
                .ThenBy(p => p.Name);

            foreach (var planet in orderedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        /*private bool CheckBothPlanetsOwnNuclearWeapon(IPlanet p1, IPlanet p2)
        {
            return p1.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)) &&
                   p2.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon));
        }

        private bool CheckBothPlanetsDoesNotOwnNuclearWeapon(IPlanet p1, IPlanet p2)
        {
            return !p1.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)) &&
                   !p2.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon));
        }*/

        private string AfterWinningTheWar(IPlanet winner, IPlanet loser, IRepository<IPlanet> planetRepo)
        {
            winner.Spend(winner.Budget / 2);
            winner.Profit(loser.Budget / 2);

            double sumLoserForcesAndWeaponPrices = loser.Army.Sum(a => a.Cost) + 
                                                   loser.Weapons.Sum(w => w.Price);

            winner.Profit(sumLoserForcesAndWeaponPrices);

            planetRepo.RemoveItem(loser.Name);

            return string.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
        }
    }
}
