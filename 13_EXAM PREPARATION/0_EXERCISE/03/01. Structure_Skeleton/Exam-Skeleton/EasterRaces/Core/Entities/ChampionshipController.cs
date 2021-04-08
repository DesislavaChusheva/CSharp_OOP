using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IRacer> driverRepository;
        private readonly IRepository<ICar> carRepository;
        private readonly IRepository<IRace> raceRepository;
        public ChampionshipController()
        {
            driverRepository = new DriverRepository();
            carRepository = new CarRepository();
            raceRepository = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            if (driverRepository.GetByName(driverName) == null)
            {
                throw new InvalidOperationException(string.Format(Utilities.Messages.ExceptionMessages.DriverNotFound, driverName));
            }
            if (carRepository.GetByName(carModel) == null)
            {
                throw new InvalidOperationException(string.Format(Utilities.Messages.ExceptionMessages.CarNotFound, carModel));
            }
            driverRepository.GetByName(driverName).AddCar(carRepository.GetByName(carModel));
            return string.Format(Utilities.Messages.OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(Utilities.Messages.ExceptionMessages.RaceNotFound, raceName));
            }
            if (driverRepository.GetByName(driverName) == null)
            {
                throw new InvalidOperationException(string.Format(Utilities.Messages.ExceptionMessages.DriverNotFound, driverName));
            }
            raceRepository.GetByName(raceName).AddDriver(driverRepository.GetByName(driverName));
            return string.Format(Utilities.Messages.OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            type = type + "Car";
            ICar car = null;
            switch (type)
            {
                case nameof(MuscleCar):
                    car = new MuscleCar(model, horsePower);
                    break;
                case nameof(SportsCar):
                    car = new SportsCar(model, horsePower);
                    break;
                default:
                    break;
            }
            carRepository.Add(car);
            return string.Format(Utilities.Messages.OutputMessages.CarCreated, type, model);

        }

        public string CreateDriver(string driverName)
        {
            IRacer driver = new Driver(driverName);
            driverRepository.Add(driver);
            return string.Format(Utilities.Messages.OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);
            raceRepository.Add(race);
            return string.Format(Utilities.Messages.OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            if (raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(Utilities.Messages.ExceptionMessages.RaceNotFound, raceName));
            }
            if (raceRepository.GetByName(raceName).Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(Utilities.Messages.ExceptionMessages.RaceInvalid, raceName, 3));
            }
            IRace race = raceRepository.GetByName(raceName);
            IRacer[] winners = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                                           .Take(3)
                                           .ToArray();
            raceRepository.Remove(race);
            return $"Driver {winners[0].Name} wins {raceName} race." + Environment.NewLine +
                   $"Driver {winners[1].Name} is second in {raceName} race." + Environment.NewLine +
                   $"Driver {winners[2].Name} is third in {raceName} race.";

        }
    }
}
