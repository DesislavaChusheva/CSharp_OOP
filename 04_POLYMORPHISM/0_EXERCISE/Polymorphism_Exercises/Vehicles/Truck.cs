using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : IVehicle
    {
        private const double increaseLt = 1.6;
        public Truck(double fuelQuantity, double consumption, double capacity)
        {
            if (fuelQuantity < capacity)
            {
                FuelQuantity = 0;
            }
            else
            {
                FuelQuantity = fuelQuantity;
            }
            Consumption = consumption + increaseLt;
            TankCapacity = capacity;
        }
        public double FuelQuantity { get; private set; }

        public double Consumption { get; private set; }

        public double TankCapacity { get; private set; }

        public void Drive(double km)
        {
            double needeFuel = Consumption * km;
            if (needeFuel > FuelQuantity)
            {
                Console.WriteLine("Truck needs refueling");
                return;
            }
            FuelQuantity -= needeFuel;
            Console.WriteLine($"Truck travelled {km} km");
        }

        public void Refuel(double lt)
        {
            if (lt <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            if (TankCapacity - FuelQuantity < lt)
            {
                Console.WriteLine($"Cannot fit {lt} fuel in the tank");
                return;
            }
            FuelQuantity += lt;
        }
    }
}
