using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private IRepository<IMilitaryUnit> units;
        private IRepository<IWeapon> weapons;
        private string name;
        private double budget;
        private double militaryPower;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                budget = value;
            }
        }

        public double MilitaryPower
        {
            get
            {
                militaryPower = CalculateMilitaryPower();

                return Math.Round(militaryPower, 3);
            }
            private set => militaryPower = value;

        }

        public IReadOnlyCollection<IMilitaryUnit> Army
            => units.Models;

        public IReadOnlyCollection<IWeapon> Weapons
            => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
            => units.AddItem(unit);

        public void AddWeapon(IWeapon weapon)
            => weapons.AddItem(weapon);

        public void TrainArmy()
        {
            foreach (var militaryUnit in units.Models)
            {
                militaryUnit.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (amount > Budget)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            Budget -= amount;
        }

        public void Profit(double amount)
            => Budget += amount;

        public string PlanetInfo()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.Append("--Forces: ");

            if (units.Models.Any())
            {
                var u = new Queue<string>();

                foreach (var item in Army)
                {
                    u.Enqueue(item.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", u));
            }
            else
            {
                sb.AppendLine("No units");
            }

            sb.Append("--Combat equipment: ");
            if (weapons.Models.Any())
            {
                var w = new Queue<string>();

                foreach (var item in Weapons)
                {
                    w.Enqueue(item.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", w));
            }
            else
            {
                sb.AppendLine("No weapons");
            }
            
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        private double CalculateMilitaryPower()
        {
            double total = units.Models.Sum(u => u.EnduranceLevel) + weapons.Models.Sum(w => w.DestructionLevel);

            if (units.Models.Any(u => u.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                total *= 1.3;
            }

            if (weapons.Models.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
            {
                total *= 1.45;
            }

            return total;
        }
    }
}
