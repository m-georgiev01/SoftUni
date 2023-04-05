using System;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private const int MaxEnduranceLevel = 20;

        private int enduranceLevel;

        protected MilitaryUnit(double cost)
        {
            Cost = cost;
            EnduranceLevel = 1;
        }

        public double Cost { get; private set; }

        public int EnduranceLevel
        {
            get => enduranceLevel;
            private set
            {
                if (value > MaxEnduranceLevel)
                {
                    enduranceLevel = MaxEnduranceLevel;

                    throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
                }

                enduranceLevel = value;
            }
        }

        public void IncreaseEndurance()
            => EnduranceLevel++;
    }
}
