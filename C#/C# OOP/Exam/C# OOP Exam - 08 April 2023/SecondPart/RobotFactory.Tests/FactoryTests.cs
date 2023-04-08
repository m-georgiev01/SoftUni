using System.Collections.Generic;
using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class FactoryTests
    {
        private Factory factory;
        private const string FactoryName = "F1";
        private const int FactoryCapacity = 2;

        [SetUp]
        public void Setup()
        {
            factory = new Factory(FactoryName, FactoryCapacity);
        }

        [TearDown]
        public void TearDown()
        {
            factory = null;
        }

        [Test]
        public void FactoryConstructorCreateSuccessfully()
        {
            factory = new Factory(FactoryName, FactoryCapacity);

            Assert.That(factory.Name, Is.EqualTo(FactoryName));
            Assert.That(factory.Capacity, Is.EqualTo(FactoryCapacity));
            Assert.That(factory.Robots.Count, Is.EqualTo(0));
            Assert.That(factory.Supplements.Count, Is.EqualTo(0));
        }

        [Test]
        public void ProduceRobotWorksCorrectlyIfCapacityIsNotReached()
        {
            string expected = "Produced --> Robot model: R1 IS: 404, Price: 10.00";
            string actual = factory.ProduceRobot("R1", 10, 404);

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(factory.Robots.Count, Is.EqualTo(1));
            Assert.That(factory.Robots[0].Model, Is.EqualTo("R1"));
            Assert.That(factory.Robots[0].Price, Is.EqualTo(10));
            Assert.That(factory.Robots[0].InterfaceStandard, Is.EqualTo(404));
        }

        [Test]
        public void ProduceRobotDoesNotAddRobotIfCapacityIsReached()
        {
            factory.ProduceRobot("R1", 10, 404);
            factory.ProduceRobot("R2", 11, 101);
            string expected = "The factory is unable to produce more robots for this production day!";
            string actual = factory.ProduceRobot("R3", 13, 202);

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(factory.Robots.Count, Is.EqualTo(2));
        }

        [Test]
        public void ProduceSupplementWorksCorrectly()
        {
            string expected = "Supplement: S1 IS: 404";

            string actual = factory.ProduceSupplement("S1", 404);

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(factory.Supplements.Count, Is.EqualTo(1));
        }

        [Test]
        public void UpgradeRobotWorksCorrectly()
        {
            Robot robot = new Robot("R1", 10, 404);
            Supplement supplement = new Supplement("S1", 404);

            bool expected = true;
            List<Supplement> expectedList = new List<Supplement>();
            expectedList.Add(supplement);

            bool actual = factory.UpgradeRobot(robot, supplement);

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(robot.Supplements.Count, Is.EqualTo(1));
            Assert.That(robot.Supplements, Is.EquivalentTo(expectedList));
        }

        [Test]
        public void UpgradeRobotThrowsIfRobotAlreadyContainsTheSupplement()
        {
            Robot robot = new Robot("R1", 10, 404);
            Supplement supplement = new Supplement("S1", 404);
            factory.UpgradeRobot(robot, supplement);

            bool expected = false;
            bool actual = factory.UpgradeRobot(robot, supplement);

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(robot.Supplements.Count, Is.EqualTo(1));
        }

        [Test]
        public void UpgradeRobotThrowsIfInterfaceStandartsDoesNotMatch()
        {
            Robot robot = new Robot("R1", 10, 404);
            Supplement supplement = new Supplement("S1", 100);

            bool expected = false;
            bool actual = factory.UpgradeRobot(robot, supplement);

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(robot.Supplements.Count, Is.EqualTo(0));
        }

        [Test]
        public void SellRobotReturnsNullIfThereAreNoRobots()
        {
            Robot expected = null;
            Robot actual = factory.SellRobot(10);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(10)]
        [TestCase(9)]
        public void SellRobotWorkdsCorrectly(double price)
        {
            factory.ProduceRobot("R1", 5, 404);
            factory.ProduceRobot("R2", price, 400);

            Robot actual = factory.SellRobot(10);

            Assert.That(actual.Model, Is.EqualTo("R2"));
            Assert.That(actual.Price, Is.EqualTo(price));
            Assert.That(actual.InterfaceStandard, Is.EqualTo(400));
        }
    }
}