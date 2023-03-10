namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int WarriorPower = 100;

        public Warrior(string name) 
            : base(name, WarriorPower)
        {
        }

        public override string CastAbility()
        {
            return $"{base.CastAbility()} hit for {Power} damage";
        }
    }
}
