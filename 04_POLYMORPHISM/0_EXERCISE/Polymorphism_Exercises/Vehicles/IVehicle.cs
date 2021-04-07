using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double Consumption { get; }
        public double TankCapacity { get; }

        void Drive(double km);
        void Refuel(double lt);
    }
}
