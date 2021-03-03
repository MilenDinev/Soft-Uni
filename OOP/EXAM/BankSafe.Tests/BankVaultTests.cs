using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BankSafePropertyShouldThrowExeptionIfCellDoesNotExist()
        {
            var bankValut = new BankVault();

            Assert.Throws<ArgumentException>(() => bankValut.AddItem("A5", new Item("Milen", "23")));
            
        }

        [Test]
        public void BankSafePropertyShouldThrowExeptionIfCellAlreadyTaken()
        {
            var bankValut = new BankVault();
            bankValut.AddItem("A1", new Item("Milen", "23"));

            Assert.Throws<ArgumentException>(() => bankValut.AddItem("A1", new Item("Gosho", "23")));

        }

        [Test]
        public void BankSafePropertyShouldThrowExeptionIfItemAlreadyexist()
        {
            var bankValut = new BankVault();
            bankValut.AddItem("A1", new Item("Milen", "23"));

            Assert.Throws<InvalidOperationException>(() => bankValut.AddItem("A3", new Item("Gosho", "23")));

        }


        [Test]
        public void BankRemovePropertyShouldThrowExeptionIfCellDoesNotExist()
        {
            var bankValut = new BankVault();
            bankValut.AddItem("A1", new Item("Milen", "23"));

            Assert.Throws<ArgumentException>(() => bankValut.RemoveItem("A23", new Item("Milen", "23")));

        }


        [Test]
        public void BankRemovePropertyShouldThrowExeptionIfItemDoesNotExist()
        {
            var bankValut = new BankVault();
            var item = new Item("Gosho", "43");
            var item2 = new Item("Milen", "24");

            Assert.Throws<ArgumentException>(() => bankValut.RemoveItem("A1", item));

        }
    }
}