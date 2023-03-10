﻿namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int PaladinPower = 100;

        public Paladin(string name) 
            : base(name, PaladinPower)
        {
        }

        public override string CastAbility()
        {
            return $"{base.CastAbility()} healed for {Power}";
        }
    }
}
