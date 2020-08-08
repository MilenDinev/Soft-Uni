namespace MilitaryElite.Interfaces
{
    using System.Collections.Generic;

    public interface IEngineer : ISpecialisedSoldier
    {
        public ICollection<IRepair> Repairs { get; }
    }
}
