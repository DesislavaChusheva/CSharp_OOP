using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private Dictionary<string,IRacer> drivers;
        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            drivers = new Dictionary<string, IRacer>();
        }
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(Utilities.Messages.ExceptionMessages.InvalidName, value, 5));
                }
                name = value;
            }
        }

        public int Laps
        {
            get
            {
                return laps;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(Utilities.Messages.ExceptionMessages.InvalidNumberOfLaps, 1));
                }
                laps = value;
            }
        }

        public IReadOnlyCollection<IRacer> Drivers => drivers.Values.ToList().AsReadOnly();

        public void AddDriver(IRacer driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(Utilities.Messages.ExceptionMessages.DriverInvalid);
            }
            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(Utilities.Messages.ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            if (drivers.Values.Contains(driver))
            {
                throw new ArgumentNullException(string.Format(Utilities.Messages.ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }
            if (drivers.ContainsKey(driver.Name))
            {
                throw new ArgumentNullException(string.Format(Utilities.Messages.ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }
            drivers.Add(driver.Name, driver);
        }
    }
}
