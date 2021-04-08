using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry driver;
        private UnitDriver driverInfo;
        private UnitCar carInfo;
        [SetUp]
        public void Setup()
        {
            carInfo = new UnitCar("Model", 300, 2.5);
            driverInfo = new UnitDriver("Name", carInfo);
            driver = new RaceEntry();
        }

        [Test]
        public void ConstructorWorking()
        {
            driver = new RaceEntry();
            Assert.AreNotEqual(driver, null);
        }
        [Test]
        public void Add_ThrowsEx_WhenDriverIsNull()
        {
            driverInfo = null;
            Exception ex = Assert.Throws<InvalidOperationException>(() => driver.AddDriver(driverInfo));
            Assert.AreEqual(ex.Message, "Driver cannot be null.");
        }
        [Test]
        public void Add_ThrowsEx_WhenDriverExists()
        {
            driver.AddDriver(driverInfo);
            Exception ex = Assert.Throws<InvalidOperationException>(() => driver.AddDriver(driverInfo));
            Assert.AreEqual(ex.Message, $"Driver {driverInfo.Name} is already added.");
        }
        [Test]
        public void AddWorking()
        {
            Assert.AreEqual(driver.AddDriver(driverInfo), $"Driver {driverInfo.Name} added in race.");
        }
        [Test]
        public void CalculateAverageHorsePower_ThrowsEx_WhenNotEnoughRaisers()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() => driver.CalculateAverageHorsePower());
            Assert.AreEqual(ex.Message, "The race cannot start with less than 2 participants.");
        }
        [Test]
        public void CalculateAverageHorsePower_Working()
        {
            UnitCar carInfo2 = new UnitCar("Model2", 200, 2.5);
            UnitDriver driverInfo2 = new UnitDriver("Name2", carInfo2);
            driver.AddDriver(driverInfo);
            driver.AddDriver(driverInfo2);
            Assert.AreEqual(driver.CalculateAverageHorsePower(), 250);
        }
    }
}