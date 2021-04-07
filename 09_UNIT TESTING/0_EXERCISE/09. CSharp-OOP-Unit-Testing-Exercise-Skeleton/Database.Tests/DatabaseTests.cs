using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database.Database database;
        int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        [SetUp]
        public void Setup()
        {
            database = new Database.Database(data);
        }

        [Test]
        public void AddCommand_ShouldThrowException_WhenCountIs16()
        {
            database = new Database.Database();
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }
        [Test]
        public void ShoudIncreaseCount_WnenAddingElement()
        {
            int expextedCount = database.Count + 1;
            database.Add(9);
            Assert.AreEqual(database.Count, expextedCount);
        }
        [Test]
        public void ConstructorWorkingCorrectly()
        {
            Assert.AreEqual(database.Count, data.Length);
        }
        [Test]
        public void RemoveCommand_ThrowsException_WhenDatabaseIsEmpty()
        {
            database = new Database.Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void RemoveCommand_DecreaeCount()
        {
            int expextedCount = database.Count - 1;
            database.Remove();
            Assert.AreEqual(database.Count, expextedCount);
        }
        [Test]
        public void FetchCommandWorkingCorrectly()
        {
            int[] firstCopy = database.Fetch();
            database.Add(9);
            int[] secondCopy = database.Fetch();
            Assert.That(firstCopy, Is.Not.EqualTo(secondCopy));
            
        }
    }
}