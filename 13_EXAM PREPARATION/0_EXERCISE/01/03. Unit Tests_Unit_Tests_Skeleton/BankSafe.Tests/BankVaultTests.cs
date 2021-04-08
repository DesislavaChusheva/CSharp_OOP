using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item item;
        [SetUp]
        public void Setup()
        {
            item = new Item("Owner", "01");
            bankVault = new BankVault();
        }

        [Test]
        public void ShouldThrowEx_WhenCellIsInvalid()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => bankVault.AddItem("A52", item));
            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }
        [Test]
        public void ShouldThrowEx_WhenCellIsNOTEmpty()
        {
            bankVault.AddItem("A1", item);
            Item item2 = new Item("Owner2", "02");
            Exception ex = Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", item2));
            Assert.AreEqual(ex.Message, "Cell is already taken!");
        }
        [Test]
        public void ShouldThrowEx_WhenItemIsUsed()
        {
            bankVault.AddItem("A1", item);
            Exception ex = Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("A2", item));
            Assert.AreEqual(ex.Message, "Item is already in cell!");
        }
        [Test]
        public void ShouldAddItem_WhenCorrectItem()
        {
            Assert.AreEqual(bankVault.AddItem("A1", item), $"Item:{item.ItemId} saved successfully!");
        }
        [Test]
        public void ShouldThrowEx_WhenCellToRemoveIsInvalid()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A52", item));
            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }
        [Test]
        public void ShouldThrowEx_WhenCellToRemoveDoesNotContainsItem()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", item));
            Assert.AreEqual(ex.Message, "Item in that cell doesn't exists!");
        }
        [Test]
        public void ShouldRemoveItem_WhenCorrectItem()
        {
            bankVault.AddItem("A1", item);
            Assert.AreEqual(bankVault.RemoveItem("A1", item), $"Remove item:{item.ItemId} successfully!");
        }
    }
}