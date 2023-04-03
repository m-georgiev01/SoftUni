using NUnit.Framework.Constraints;

namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        private const string TestCarMake = "Volkswagen";
        private const string TestCarModel = "Golf";
        private const double TestCarFuelConsumption = 7;
        private const double TestCarFuelCapacity = 60;

        private const string EmptyString = "";
        private const string WhiteSpace = " ";

        [SetUp]
        public void SetUp()
        {
            car = new Car(TestCarMake, TestCarModel, TestCarFuelConsumption, TestCarFuelCapacity);
        }

        [TearDown]
        public void TearDown()
        {
            car = null;
        }

        [Test]
        public void CreateCar()
        {
            car = new Car(TestCarMake, TestCarModel, TestCarFuelConsumption, TestCarFuelCapacity);

            Assert.That(car.Make, Is.EqualTo(TestCarMake));
            Assert.That(car.Model, Is.EqualTo(TestCarModel));
            Assert.That(car.FuelConsumption, Is.EqualTo(TestCarFuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(TestCarFuelCapacity));
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        [TestCase(null)]
        [TestCase(EmptyString)]
        public void MakeShouldThrowIfNullOrEmpty(string make)
        {
            ArgumentException exeption = Assert
                .Throws<ArgumentException>(() => car = new Car(make, TestCarModel, TestCarFuelConsumption, TestCarFuelCapacity));

            Assert.That(exeption.Message, Is.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        [TestCase(null)]
        [TestCase(EmptyString)]
        public void ModelShouldThrowIfNullOrEmpty(string model)
        {
            ArgumentException exeption = Assert
                .Throws<ArgumentException>(() => car = new Car(TestCarMake, model, TestCarFuelConsumption, TestCarFuelCapacity));

            Assert.That(exeption.Message, Is.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelConsumptionShouldThrowIfZeroOrNegative(double fuelConsumption)
        {
            ArgumentException exeption = Assert
                .Throws<ArgumentException>(() => car = new Car(TestCarMake, TestCarModel, fuelConsumption, TestCarFuelCapacity));

            Assert.That(exeption.Message, Is.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelCapacityShouldThrowIfZeroOrNegative(double fuelCapacity)
        {
            ArgumentException exeption = Assert
                .Throws<ArgumentException>(() => car = new Car(TestCarMake, TestCarModel, TestCarFuelConsumption, fuelCapacity));

            Assert.That(exeption.Message, Is.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        public void RefuelMethodAddingCorrectly()
        {
            car.Refuel(10);

            Assert.That(car.FuelAmount, Is.EqualTo(10));
        }

        [Test]
        public void RefuelMethodNotAddingMoreThanFuelCapacity()
        {
            car.Refuel(65);

            Assert.That(car.FuelAmount, Is.EqualTo(TestCarFuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void TestRefuelAmouthIsGreaterThanZero(double fuelAmount)
        {
            ArgumentException exeption = Assert
                .Throws<ArgumentException>(() => car.Refuel(fuelAmount));

            Assert.That(exeption.Message, Is.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void DriveMethodRemovingFuelCorrectly()
        {
            car.Refuel(10);
            car.Drive(100);

            double expected = 3;

            Assert.That(car.FuelAmount, Is.EqualTo(expected));
        }

        [Test]
        public void DriveMethodThrowIfNotEnoughFuel()
        {
            car.Refuel(1.5);

            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => car.Drive(100));

            Assert.That(exeption.Message, Is.EqualTo("You don't have enough fuel to drive!"));
        }
    }
}