using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Models.Races.Contracts
{
    using System.Collections.Generic;

    public interface IRace
    {
        string Name { get; }

        int Laps { get; }

        IReadOnlyCollection<IRacer> Drivers { get; }

        void AddDriver(IRacer driver);
    }
}