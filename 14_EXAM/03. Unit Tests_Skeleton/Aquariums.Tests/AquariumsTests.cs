namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class AquariumsTests
    {
        private string name;
        private int capacity;
        private Aquarium aquarium;
        [SetUp]
        public void SetUp()
        {
            name = "myAquarium";
            capacity = 20;            
            aquarium = new Aquarium(name, capacity);
            for (int i = 1; i <= 20; i++)
            {
                aquarium.Add(new Fish($"{i}"));
            }
        }
        [Test]
        public void TestConstructor()
        {
            aquarium = new Aquarium(name, capacity);
            Assert.AreNotEqual(aquarium, null);
        }
        [Test]
        public void Name_ShouldThrowEx_WhenEmpty()
        {
            name = null;
            Exception ex = Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium(name, capacity));
            Assert.AreEqual(ex.Message.Contains("Invalid aquarium name!"), true);
        }
        [Test]
        public void Name_Working()
        {
            Assert.AreEqual(aquarium.Name, name);
        }
        [Test]
        public void Capacity_ShouldThrowEx_WhenNegative()
        {
            capacity = -1;
            Exception ex = Assert.Throws<ArgumentException>(() => aquarium = new Aquarium(name, capacity));
            Assert.AreEqual(ex.Message.Contains("Invalid aquarium capacity!"), true);
        }
        [Test]
        public void Capacity_Working()
        {
            Assert.AreEqual(aquarium.Capacity, capacity);
        }
        [Test]
        public void Add_ThrowsEx_WhenAqIsFull()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("21")));
            Assert.AreEqual(ex.Message.Contains("Aquarium is full!"), true);
        }
        [Test]
        public void Add_Working()
        {
            aquarium = new Aquarium(name, capacity);
            aquarium.Add(new Fish("1"));
            Assert.AreEqual(aquarium.Count, 1);
        }
        [Test]
        public void Remove_ThrowsEx_WhenFishDoeNOTExist()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("50"));
            Assert.AreEqual(ex.Message.Contains("Fish with the name 50 doesn't exist!"), true);
        }
        [Test]
        public void Remove_Working()
        {
            aquarium.RemoveFish("1");
            Assert.AreEqual(aquarium.Count, capacity - 1);
        }
        [Test]
        public void Sell_ThrowsEx_WhenFishDoesNOTExist()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("50"));
            Assert.AreEqual(ex.Message.Contains("Fish with the name 50 doesn't exist!"), true);
        }
        [Test]
        public void Sell_Working()
        {
            Fish fish = new Fish("1");
            aquarium = new Aquarium(name, capacity);
            aquarium.Add(fish);
            Assert.AreEqual(aquarium.SellFish("1"),fish);
        }
        [Test]
        public void Report_Working()
        {
            aquarium = new Aquarium(name, capacity);
            aquarium.Add(new Fish("1"));
            aquarium.Add(new Fish("2"));
            aquarium.Add(new Fish("3"));
            Assert.AreEqual(aquarium.Report().Contains($"Fish available at {aquarium.Name}: 1, 2, 3"), true);
        }
    }
}
