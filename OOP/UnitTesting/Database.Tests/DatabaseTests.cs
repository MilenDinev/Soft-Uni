using NUnit.Framework;
using Database;
using System.Linq;
using System;


    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldBeInitializedWith16Elements()
        {
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database.Database database = new Database.Database(numbers);

            var expectedResult = 16;
            var actualResult = database.Count;

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void ConstructorShouldBeThrowExceptionIfThereAreNot16Elements()
        {
            int[] numbers = Enumerable.Range(1, 10).ToArray();
            Database.Database database = new Database.Database(numbers);

            var expectedResult = 10;
            var actualResult = database.Count;

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]  
        public void AddOperationShouldAddElementAtNextFreeCell()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 10).ToArray();
            Database.Database database = new Database.Database(numbers);
            //Act
            database.Add(5);
            // Assert
            var allEments = database.Fetch();
            var expectedValue = 5;
            var actualResult = allEments[allEments.Length - 1];
            var expectedCount = 11;
            var actualCount = database.Count;
            Assert.AreEqual(expectedValue, actualResult);
            Assert.AreEqual(expectedCount, actualCount);
    }

        [Test]

        public void AddOperationShouldThrowExeptionIfElementAreAbove16()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(10));
        }

        [Test]
        [TestCase(1,16,15,14, 15)]

        public void RemoveOperationShouldSupportOnlyRemovingAnElementAtTheLastIndex(int startIndex, int count, int result, int index, int expectedCount)
        {
            //Arrange
            int[] numbers = Enumerable.Range(startIndex, count).ToArray();
            Database.Database database = new Database.Database(numbers);
            //Act
            database.Remove();

            // Assert
            var expectedValue = result;
            var allEments = database.Fetch();
            var actualResult = allEments[index];
            var actualCount = database.Count;

            Assert.AreEqual(expectedValue, actualResult);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]

        public void RemoveOperationShouldThrowExeptionIfDatabaseIsEmpty()
        {
            //Arrange
            Database.Database database = new Database.Database();

            // Act Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }


        [Test]

        public void FetchShouldReturnAllElements()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 5).ToArray();
            Database.Database database = new Database.Database(numbers);

            // Act 
            var allItems = database.Fetch();
            //Assert

            int[] expectedValue = { 1, 2, 3, 4, 5 };

            CollectionAssert.AreEqual(expectedValue, allItems);

        }
    }
