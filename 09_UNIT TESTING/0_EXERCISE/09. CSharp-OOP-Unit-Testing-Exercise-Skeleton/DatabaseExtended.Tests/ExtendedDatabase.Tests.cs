using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;
        private Person[] people = new Person[16];

        [SetUp]
        public void Setup()
        {
            for (int i = 0; i < 16; i++)
            {
                Person currPerson = new Person(i, $"{i}");
                people[i] = currPerson;
            }
            database = new ExtendedDatabase.ExtendedDatabase(people);
        }

        [Test]
        public void ConstructurWorkingProperly()
        {
            Assert.AreEqual(database.Count, people.Length);
        }
        [Test]
        public void AddCommand_ThrowsException_WhenCountIsNOT16()
        {
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(17, "17")));
        }
        [Test]
        public void AddCommand_ThrowsException_WhenUserNameExists()
        {
            database = new ExtendedDatabase.ExtendedDatabase();
            database.Add(new Person(1, "Username"));

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(2, "Username")));
        }
        [Test]
        public void AddCommand_ThrowsException_WhenUserIDExists()
        {
            database = new ExtendedDatabase.ExtendedDatabase();
            database.Add(new Person(1, "Username"));

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1, "Username2")));
        }
        [Test]
        public void AddCommand_IncreaseCount()
        {
            database = new ExtendedDatabase.ExtendedDatabase();
            database.Add(new Person(1, "Username"));
            Assert.AreEqual(database.Count, 1);
        }
        [Test]
        public void AddRangeCommand_ThrowsException_WhenlenghtIsOver16()
        {
            Person[] morePeople = new Person[17];
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase.ExtendedDatabase(morePeople));
        }
        [Test]
        public void RemoveCommand_ThrowsException_WhenDatabaseIsEmpty()
        {
            database = new ExtendedDatabase.ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void RemoveCommand_DecreaseCount()
        {
            int expectedCount = database.Count - 1;
            database.Remove();
            Assert.AreEqual(database.Count, expectedCount);
        }
        [Test]
        public void FindByUserName_ThrowsException_WhenNameIsEmpty()
        {
            string name = null;
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(name));
        }
        [Test]
        public void FindByUserName_ThrowsException_WhenNameDoesNotExist()
        {
            string name = "20";
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(name));
        }
        [Test]
        public void FindByUserName_ReturnsPerson()
        {
            string name = "8";
            Assert.AreEqual(database.FindByUsername(name).UserName, name);
        }
        [Test]
        public void FindByID_ThrowsException_WhenNameIsNegateive()
        {
            int id = -5;
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));
        }
        [Test]
        public void FindByID_ThrowsException_WhenIDDoesNOTExist()
        {
            int id = 20;
            Assert.Throws<InvalidOperationException>(() => database.FindById(id));
        }
        [Test]
        public void FindById_ReturndPerson()
        {
            int id = 8;
            Assert.AreEqual(database.FindById(id).Id, id);
        }
    }
}