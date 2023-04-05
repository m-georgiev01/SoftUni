using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void WeaponCreateCorrectly()
            {
                var weapon = new Weapon("w1", 7.5, 5);

                Assert.That(weapon.Name, Is.EqualTo("w1"));
                Assert.That(weapon.Price, Is.EqualTo(7.5));
                Assert.That(weapon.DestructionLevel, Is.EqualTo(5));
            }

            [Test]
            public void WeaponPriceSetterThrowsOnNegativeValue()
            {
                ArgumentException exception = Assert.Throws<ArgumentException>(() => new Weapon("w1", -1, 5));

                Assert.That(exception.Message, Is.EqualTo("Price cannot be negative."));
            }

            [Test]
            public void WeaponIncreaseDestructionLevelWorkingCorrectly()
            {
                var weapon = new Weapon("w1", 7.5, 5);
                weapon.IncreaseDestructionLevel();

                Assert.That(weapon.DestructionLevel, Is.EqualTo(6));
            }

            [Test]
            [TestCase(9)]
            [TestCase(2)]
            public void WeaponIsNuclearReturnsFalseOnValueSmallerThan10(int destructionLevel)
            {
                var weapon = new Weapon("w1", 7.5, destructionLevel);

                Assert.That(weapon.IsNuclear, Is.EqualTo(false));
            }

            [Test]
            [TestCase(10)]
            [TestCase(29)]
            public void WeaponIsNuclearReturnsTrueOnValueEqualOrGreaterThan10(int destructionLevel)
            {
                var weapon = new Weapon("w1", 7.5, destructionLevel);

                Assert.That(weapon.IsNuclear, Is.EqualTo(true));
            }

            [Test]
            public void PlanetCreateCorrectly()
            {
                var planet = new Planet("p1", 100.5);

                Assert.That(planet.Name, Is.EqualTo("p1"));
                Assert.That(planet.Budget, Is.EqualTo(100.5));
                Assert.That(planet.Weapons.Count, Is.EqualTo(0));
            }

            [Test]
            [TestCase(null)]
            [TestCase("")]
            public void PlanetNameSetterThrowsOnNullOrEmpty(string name)
            {
                ArgumentException exception = Assert.Throws<ArgumentException>(() => new Planet(name, 100.5));

                Assert.That(exception.Message, Is.EqualTo("Invalid planet Name"));
            }

            [Test]
            public void PlanetBudgetSetterThrowsOnNegativeValue()
            {
                ArgumentException exception = Assert.Throws<ArgumentException>(() => new Planet("p1", -1));

                Assert.That(exception.Message, Is.EqualTo("Budget cannot drop below Zero!"));
            }

            [Test]
            public void PlanetWeaponsGetterWorkCorrectly()
            {
                var planet = new Planet("p1", 100.5);
                var weapon = new Weapon("w1", 7.5, 5);

                planet.AddWeapon(weapon);

                var expected = new List<Weapon>();
                expected.Add(weapon);

                Assert.That(planet.Weapons, Is.EquivalentTo(expected));
            }

            [Test]
            public void PlanetMilitaryPowerRatioGetterWorkCorrectly()
            {
                var planet = new Planet("p1", 100.5);
                var weapon = new Weapon("w1", 7.5, 5);

                planet.AddWeapon(weapon);

                var expected = 5;
                
                Assert.That(planet.MilitaryPowerRatio, Is.EqualTo(expected));
            }

            [Test]
            public void PlanetProfitMethodWorksCorrectly()
            {
                var planet = new Planet("p1", 100.5);
                planet.Profit(10);

                double expected = 110.5;

                Assert.That(planet.Budget, Is.EqualTo(expected));
            }

            [Test]
            public void PlanetSpendFundsThrowsOnLargerThanBudgetAmount()
            {
                var planet = new Planet("p1", 100.5);
                InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(100.51));

                Assert.That(exception.Message, Is.EqualTo("Not enough funds to finalize the deal."));
            }

            [Test]
            [TestCase(100.5)]
            [TestCase(50)]
            public void PlanetSpendFundsWorksCorrectly(double amount)
            {
                var planet = new Planet("p1", 100.5);
                double expected = planet.Budget - amount;

                planet.SpendFunds(amount);

                Assert.That(planet.Budget, Is.EqualTo(expected));
            }

            [Test]
            public void PlanetAddWeaponThrowsIfNameNotUnique()
            {
                var planet = new Planet("p1", 100.5);
                var weapon = new Weapon("w1", 7.5, 5);

                planet.AddWeapon(weapon);

                InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon));

                Assert.That(exception.Message, Is.EqualTo($"There is already a {weapon.Name} weapon."));
            }

            [Test]
            public void PlanetAddWeaponWorksCorrectly()
            {
                var planet = new Planet("p1", 100.5);
                var weapon = new Weapon("w1", 7.5, 5);
                var weapon2 = new Weapon("w2", 2, 3);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                Assert.That(planet.Weapons.Count, Is.EqualTo(2));
            }

            [Test]
            public void PlanetRemoveWeaponWorksCorrectly()
            {
                var planet = new Planet("p1", 100.5);
                var weapon = new Weapon("w1", 7.5, 5);
                var weapon2 = new Weapon("w2", 2, 3);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                planet.RemoveWeapon(weapon2.Name);

                Assert.That(planet.Weapons.Count, Is.EqualTo(1));
                Assert.That(planet.Weapons.First().Name, Is.EqualTo(weapon.Name));
            }


            [Test]
            public void PlanetUpgradeWeaponThrowsIfWeaponNotFound()
            {
                var planet = new Planet("p1", 100.5);

                InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("weapon"));

                Assert.That(exception.Message, Is.EqualTo($"weapon does not exist in the weapon repository of {planet.Name}"));
            }

            [Test]
            public void PlanetUpgradeWeaponWorksCorrectly()
            {
                var planet = new Planet("p1", 100.5);
                var weapon = new Weapon("w1", 7.5, 5);

                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weapon.Name);

                Assert.That(planet.Weapons.First().DestructionLevel, Is.EqualTo(6));
            }

            [Test]
            public void PlanetDestructOpponentThrowsIfOpponentTopStrong()
            {
                var planet = new Planet("p1", 100.5);
                var planet2 = new Planet("p2", 200);

                var weapon = new Weapon("w1", 7.5, 5);
                planet2.AddWeapon(weapon);

                InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(planet2));

                Assert.That(exception.Message, Is.EqualTo($"{planet2.Name} is too strong to declare war to!"));
            }

            [Test]
            public void PlanetDestructOpponentWorksCorrectly()
            {
                var planet = new Planet("p1", 100.5);
                var planet2 = new Planet("p2", 200);

                var weapon = new Weapon("w1", 7.5, 5);
                planet.AddWeapon(weapon);

                string expected = $"{planet2.Name} is destructed!";

                Assert.That(planet.DestructOpponent(planet2), Is.EqualTo(expected));
            }
        }
    }
}
