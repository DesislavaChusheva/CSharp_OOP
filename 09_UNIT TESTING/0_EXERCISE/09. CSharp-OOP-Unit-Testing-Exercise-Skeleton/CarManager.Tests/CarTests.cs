
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        string make;
        string model;
        double fuelConsumption;
        double fuelCapacity;
        [SetUp]
        public void Setup()
        {
            make = "Make";
            model = "Model";
            fuelConsumption = 10.5;
            fuelCapacity = 30.5;
            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void ThrowEx_WhenMake_Null()
        {
            make = null;
            Exception ex = Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
            Assert.AreEqual(ex.Message, "Make cannot be null or empty!");
        }
        [Test]
        public void Make_Working()
        {
            Assert.AreEqual(car.Make, "Make");
        }
        [Test]
        public void ThrowEx_WhenModel_Null()
        {
            model = null;
            Exception ex = Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
            Assert.AreEqual(ex.Message, "Model cannot be null or empty!");
        }
        [Test]
        public void Model_Working()
        {
            Assert.AreEqual(car.Model, "Model");
        }
        [Test]
        public void ThrowEx_WhenFuelConsumption_LessThanOrEqualZero()
        {
            fuelConsumption = 0;
            Exception ex = Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
            Assert.AreEqual(ex.Message, "Fuel consumption cannot be zero or negative!");
        }
        [Test]
        public void FuelConsumption_Working()
        {
            Assert.AreEqual(car.FuelConsumption, 10.5);
        }
        [Test]
        public void ThrowEx_WhenFuelCapacity_LessThanOrEqualToZero()
        {
            fuelCapacity = 0;
            Exception ex = Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
            Assert.AreEqual(ex.Message, "Fuel capacity cannot be zero or negative!");
        }
        [Test]
        public void FuelCapacity_Working()
        {
            Assert.AreEqual(car.FuelCapacity, 30.5);
        }
        [Test]
        public void ThrowEx_Refuel_FuelIsNegative()
        {
            double fuel = -3.0;
            Exception ex = Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
            Assert.AreEqual(ex.Message, "Fuel amount cannot be zero or negative!");
        }
        [Test]
        public void Refuel_WhenAmountIsBiggerThanCapacity_ReturnsCapacity()
        {
            double fuel = 40.0;
            car.Refuel(fuel);
            Assert.AreEqual(car.FuelAmount, car.FuelCapacity);
        }
        [Test]
        public void Refuel_Working()
        {
            double fuel = 15.0;
            car.Refuel(fuel);
            Assert.AreEqual(car.FuelAmount, fuel);
        }
        [Test]
        public void Drive_ThrowsEx_NotEnoughFuel()
        {
            car.Refuel(20.0);
            Exception ex = Assert.Throws<InvalidOperationException>(() => car.Drive(500));
            Assert.AreEqual(ex.Message, "You don't have enough fuel to drive!");
        }
        [Test]
        public void Drive_Working()
        {
            car.Refuel(20.0);
            double distance = 5;
            double fuelNeeded = (distance / 100) * car.FuelConsumption;
            double exp = car.FuelAmount - fuelNeeded;
            car.Drive(distance);
            Assert.AreEqual(car.FuelAmount, exp);
        }
    }
}