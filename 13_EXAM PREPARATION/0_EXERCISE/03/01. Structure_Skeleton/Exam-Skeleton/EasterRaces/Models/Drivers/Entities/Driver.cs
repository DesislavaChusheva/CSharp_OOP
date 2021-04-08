using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers
{
    public class Driver : IRacer
    {
        private string name;
        private ICar car;
        private int numberOfWins;
        private bool canParticipate;
        public Driver(string name)
        {
            Name = name;
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

        public ICar Car { get { return car; } private set { } }

        public int NumberOfWins { get { return numberOfWins; } private set { } }

        public bool CanParticipate
        {
            get
            {
                return canParticipate;
            }
            private set
            {
                if (Car != null)
                {
                    canParticipate = true;
                }
                canParticipate = false; ;
            }
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(Utilities.Messages.ExceptionMessages.CarInvalid);
            }
            this.Car = car;
            canParticipate = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
