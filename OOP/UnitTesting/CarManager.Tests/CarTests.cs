using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Lexus", "IS250", 10, 100, 0)]
        [TestCase("Honda", "Accord", 6, 80, 0)]
        public void CarConstructorShouldSetAllDataCorrect(string make, string model, double fuelConsumtion, double fuelCapacity, double fuelAmount)
        {
            //Arrange Act
            Car car = new Car(make:make, 
                model:model, 
                fuelConsumption: fuelConsumtion, 
                fuelCapacity: fuelCapacity);

            //Assert
            Assert.AreEqual(car.Make, make);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.FuelConsumption, fuelConsumtion);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
            Assert.AreEqual(car.FuelAmount, fuelAmount);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]

        public void CarConstructorShouldThrowExeptionIfMakeIsNullOrEmpty(string make)
        {
            Assert.Throws < ArgumentException>(() => new Car(make, "model", 10, 10));
        }


        [Test]
        [TestCase("")]
        [TestCase(null)]

        public void CarConstructorShouldThrowExeptionIfModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("lexus", model, 10, 10));
        }



        [Test]
        [TestCase(0)]
        [TestCase(-10)]

        public void CarConstructorShouldThrowExeptionIfFuelConsumptionIsBelowOrEqualToZero(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("Lexus", "model", fuelConsumption, 10));
        }

        [Test]
        [TestCase(-20)]
        [TestCase(-10)]

        public void CarConstructorShouldThrowExeptionIfFuelCapacityIsBelowOrEqualToZero(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("Lexus", "model", 10, fuelCapacity));
        }



        [Test]
        [TestCase(0)]


        public void RefuelShouldThrowExeptionWhenPassedValueIsBellowOrEqualToZero( double refuel)
        {
            Car car = new Car("Lexus", "IS250", 10, 130);
            Assert.Throws<ArgumentException>(() => car.Refuel(refuel));
        }

        [Test]
        [TestCase(130, 150, 130)]


        public void RefuelShouldWorksAsExpected(double fuelCapacity, double refuel, double expectedResult)
        {
            //Arrange
            Car car = new Car("Lexus", "IS250", 10, fuelCapacity);
            //Act
            car.Refuel(refuel);
            //Assert
            var actualResult = car.FuelAmount;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(50, 501)]

        public void DriveShouldThrowExeptionIfFuelAmountIsNotEnough(double fuelToRefuel, double distance)
        {
            //Arrange 
            Car car = new Car("Lexus", "IS250", 10, 100);

            //Act
            car.Refuel(fuelToRefuel);

            //Assert

            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }

        [Test]
        [TestCase(100, 50)]

        public void DriveShouldReduceFuelBasedOnTravelledDistance(double fuelToRefuel, double desiredDistance)
        {
            //Arrange 
            Car car = new Car("Lexus", "IS250", 10, 100);        
            car.Refuel(fuelToRefuel);

            //Act
            car.Drive(desiredDistance);
            //Assert
            var expectedValue = 95;
            var actualValue = car.FuelAmount;
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}