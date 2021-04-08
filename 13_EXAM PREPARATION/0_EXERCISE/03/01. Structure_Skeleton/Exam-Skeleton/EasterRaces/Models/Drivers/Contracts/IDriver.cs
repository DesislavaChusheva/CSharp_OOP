using EasterRaces.Models.Cars.Contracts;

namespace EasterRaces.Models.Drivers.Contracts
{
    public interface IRacer
    {
        string Name { get; }

        ICar Car { get; }

        int NumberOfWins { get; }

        bool CanParticipate { get; }

        void WinRace();

        void AddCar(ICar car);
    }
}