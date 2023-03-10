namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int RoguePower = 80;

        public Rogue(string name) 
            : base(name, RoguePower)
        {
        }

        public override string CastAbility()
        {
            return $"{base.CastAbility()} hit for {Power} damage";
        }
    }
}
