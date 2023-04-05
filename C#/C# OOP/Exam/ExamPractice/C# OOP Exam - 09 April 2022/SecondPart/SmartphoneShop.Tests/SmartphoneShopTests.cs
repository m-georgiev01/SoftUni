using System;
using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Shop shop;
        private const int Capacity = 3;

        [SetUp]
        public void SetUp()
        {
            shop = new Shop(Capacity);
        }

        [TearDown]
        public void TearDowm()
        {
            shop = null;
        }

        [Test]
        public void ShopConstructorCreatesCorrectly()
        {
            shop = new Shop(Capacity);

            Assert.That(shop.Capacity, Is.EqualTo(Capacity));
            Assert.That(shop.Count, Is.EqualTo(0));
        }

        [Test]
        public void CapacitySetterThrowsIfLessThanZero()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Shop(-1));

            Assert.That(exception.Message, Is.EqualTo("Invalid capacity."));
        }

        [Test]
        public void AddMethodWorksCorrectly()
        {
            shop.Add(new Smartphone("s1", 10));

            Assert.That(shop.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddMethodThrowsIfModelNameNotUnique()
        {
            shop.Add(new Smartphone("s1", 10));

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("s1", 1)));

            Assert.That(exception.Message, Is.EqualTo("The phone model s1 already exist."));
        }

        [Test] public void AddMethodThrowsIfShopIsFull()
        {
            shop.Add(new Smartphone("s1", 10));
            shop.Add(new Smartphone("s2", 1));
            shop.Add(new Smartphone("s3", 111));

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("s4", 1)));

            Assert.That(exception.Message, Is.EqualTo("The shop is full."));
        }

        [Test]
        public void RemoveMethodWorksCorrectly()
        {
            shop.Add(new Smartphone("s1", 10));
            shop.Remove("s1");

            Assert.That(shop.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveMethodThrowsIfModelNotFound()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => shop.Remove("s2"));

            Assert.That(exception.Message, Is.EqualTo("The phone model s2 doesn't exist."));
        }

        [Test]
        public void TestPhoneWorksCorrectly()
        {
            Smartphone smartphone = new Smartphone("s1", 10);
            shop.Add(smartphone);
            shop.TestPhone("s1", 6);

            Assert.That(smartphone.CurrentBateryCharge, Is.EqualTo(4));
        }

        [Test]
        public void TestPhoneThrowsIfModelNotFound()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => shop.TestPhone("s1", 10));

            Assert.That(exception.Message, Is.EqualTo("The phone model s1 doesn't exist."));
        }

        [Test]
        public void TestPhoneThrowsIfNotEnoughBattery()
        {
            Smartphone smartphone = new Smartphone("s1", 10);
            shop.Add(smartphone);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => shop.TestPhone("s1", 11));

            Assert.That(exception.Message, Is.EqualTo($"The phone model {smartphone.ModelName} is low on batery."));
        }

        [Test]
        public void ChargePhoneWorksCorrectly()
        {
            Smartphone smartphone = new Smartphone("s1", 10);
            shop.Add(smartphone);
            shop.TestPhone(smartphone.ModelName, 6);

            Assert.That(smartphone.CurrentBateryCharge, Is.EqualTo(4));

            shop.ChargePhone(smartphone.ModelName);
            Assert.That(smartphone.CurrentBateryCharge, Is.EqualTo(smartphone.MaximumBatteryCharge));
        }


        [Test]
        public void ChargePhoneThrowsIfModelNotFound()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("s1"));

            Assert.That(exception.Message, Is.EqualTo("The phone model s1 doesn't exist."));
        }
    }
}