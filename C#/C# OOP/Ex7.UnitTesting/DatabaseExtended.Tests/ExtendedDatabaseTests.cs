using System;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        private const string EmptyString = "";

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
        public void CreateDatabaseWith2Elements()
        {
            database = new Database(new Person(1, "Pesho"), new Person(2, "Gosho"));
            Person first = database.FindById(1);
            Person second = database.FindById(2);


            Assert.That(database.Count, Is.EqualTo(2));
            Assert.That(first.UserName, Is.EqualTo("Pesho"));
            Assert.That(second.UserName, Is.EqualTo("Gosho"));
        }

        [Test]
        public void CreateDatabaseShouldThrowIfCreatedWith17Elements()
        {
            ArgumentException exeption = Assert
                .Throws<ArgumentException>(() => database = new Database(CreateArrayWith17Elements()));

            Assert.That(exeption.Message, Is.EqualTo("Provided data length should be in range [0..16]!"));

        }

        [Test]
        public void TestAddMethod()
        {
            database.Add(new Person(1, "Pesho"));
            Person p = database.FindById(1);

            Assert.That(database.Count, Is.EqualTo(1));
            Assert.That(p.UserName, Is.EqualTo("Pesho"));
        }

        [Test]
        public void AddMethodShouldThrowIfItIsAlreadyFull()
        {
            database = new Database(CreateMaxElementsArray());

            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => database.Add(new Person(1, "1")));

            Assert.That(exeption.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddMethodShouldThrowIfUsernameIsNotUnique()
        {
            database.Add(new Person(1, "Pesho"));

            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => database.Add(new Person(2, "Pesho")));

            Assert.That(exeption.Message, Is.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddShouldThrowIfNotUniqueId()
        {
            database.Add(new Person(1, "Pesho"));

            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => database.Add(new Person(1, "Gosho")));

            Assert.That(exeption.Message, Is.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void RemoveMethodShouldRemoveOnlyLastElement()
        {
            database = new Database(new Person(1, "Pesho"), new Person(2, "Gosho"));
            Person first = database.FindById(1);

            database.Remove();

            Assert.That(database.Count, Is.EqualTo(1));
            Assert.That(first.UserName, Is.EqualTo("Pesho"));
        }

        [Test]
        public void RemoveMethodShouldThrowOnEmptyDatabase()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        [TestCase(null)]
        [TestCase(EmptyString)]
        public void FindByUsernameShouldThrowIfUsernameNullOrEmpty(string username)
        {
            ArgumentNullException exeption = Assert
                .Throws<ArgumentNullException>(() => database.FindByUsername(username));

            Assert.That(exeption.ParamName, Is.EqualTo("Username parameter is null!"));
        }

        [Test]
        public void FindByUsernameShouldThrowIfUsernameDoesNotExist()
        {
            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => database.FindByUsername("Gosho"));

            Assert.That(exeption.Message, Is.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindByUsernameReturnsCorrectUser()
        {
            database = new Database(new Person(1, "Pesho"), new Person(2, "Gosho"));
            Person person = database.FindByUsername("Gosho");

            Assert.AreEqual("Gosho", person.UserName);
            Assert.AreEqual(2, person.Id);
        }

        [Test]
        public void FindByIdShouldThrowIfIdIsLessThanZero()
        {
            ArgumentOutOfRangeException exeption = Assert
                .Throws<ArgumentOutOfRangeException>(() => database.FindById(-2));

            Assert.That(exeption.ParamName, Is.EqualTo("Id should be a positive number!"));
        }

        [Test]
        public void FindByIdShouldThrowIfIdDoesNotExist()
        {
            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => database.FindById(1));

            Assert.That(exeption.Message, Is.EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void FindByIdReturnsCorrectUser()
        {
            database = new Database(new Person(1, "Pesho"), new Person(2, "Gosho"));
            Person person = database.FindById(2);

            Assert.AreEqual("Gosho", person.UserName);
            Assert.AreEqual(2, person.Id);
        }


        private Person[] CreateMaxElementsArray()
        {
            Person[] persons = new Person[16];

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, i.ToString());
            }

            return persons;
        }

        private Person[] CreateArrayWith17Elements()
        {
            Person[] persons = new Person[17];

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, i.ToString());
            }

            return persons;
        }
    }
}