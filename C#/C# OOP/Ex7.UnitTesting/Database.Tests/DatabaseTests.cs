using System;
using System.Collections;
using System.Linq;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }

        [TearDown]
        public void TearDown()
        {
            database = null;
        }

        [Test]
        public void CreateDatabaseWith5Elements()
        {
            database = new Database(1, 2, 3, 4, 5);


            Assert.That(database.Count, Is.EqualTo(5));
            Assert.That(database.Fetch()[0], Is.EqualTo(1));
        }

        [Test]
        public void TestAddMethod()
        {
            database = new Database(1);
            database.Add(2);

            Assert.That(database.Count, Is.EqualTo(2));
            Assert.That(database.Fetch()[1], Is.EqualTo(2));
        }

        [Test]
        public void AddMethodShouldThrowOnAdding17thElement()
        {
            database = new Database(FillArray());

            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => database.Add(16));

            Assert.That(exeption.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }


        [Test]
        public void RemoveMethodShouldRemoveOnlyLastElement()
        {
            database = new Database(1, 2);
            database.Remove();

            Assert.That(database.Count, Is.EqualTo(1));
            Assert.That(database.Fetch()[0], Is.EqualTo(1));
        }

        [Test]
        public void RemoveMethodShouldThrowOnEmptyDatabase()
        {

            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => database.Remove());

            Assert.That(exeption.Message, Is.EqualTo("The collection is empty!"));
        }

        [Test]
        public void FetchDataFromDatabase()
        {
            database = new Database(1, 2, 3);
            var result = database.Fetch();

            Assert.That(new int[] { 1, 2, 3 }, Is.EquivalentTo(result));
        }


        private int[] FillArray()
        {
            var arr = new int[16];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }

            return arr;
        }
    }
}
