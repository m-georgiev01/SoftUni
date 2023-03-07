namespace MilitaryElite.Models.Interfaces
{
    public interface ICommando
    {
        IReadOnlyCollection<IMission> Missions { get; }
    }
}
