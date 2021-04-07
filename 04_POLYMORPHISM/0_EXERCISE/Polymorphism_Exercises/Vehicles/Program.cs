using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carI = Console.ReadLine().Split();
            Car car = new Car(double.Parse(carI[1]), double.Parse(carI[2]), double.Parse(carI[3]));
            string[] truckI = Console.ReadLine().Split();
            Truck truck = new Truck(double.Parse(truckI[1]), double.Parse(truckI[2]), double.Parse(carI[3]));
            string[] busI = Console.ReadLine().Split();
            Bus bus = new Bus(double.Parse(busI[1]), double.Parse(busI[2]), double.Parse(busI[3]));
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = command[0];
                string vehicle = command[1];
                double kmOrLt = double.Parse(command[2]);
                switch (action)
                {
                    case "Drive":
                        if (vehicle == "Car")
                        {
                            car.Drive(kmOrLt);
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Drive(kmOrLt);
                        }
                        else if (vehicle == "Bus")
                        {
                            bus.Drive(kmOrLt);
                        }
                        break;
                    case "DriveEmpty":
                        if (vehicle == "Bus")
                        {
                            bus.DriveEmpty(kmOrLt);
                        }
                        break;
                    case "Refuel":
                        if (vehicle == "Car")
                        {
                            car.Refuel(kmOrLt);
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Refuel(kmOrLt);
                        }
                        else if (vehicle == "Bus")
                        {
                            bus.Refuel(kmOrLt);
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
