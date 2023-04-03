namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Xml.Linq;
    using static System.Net.Mime.MediaTypeNames;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        private const string TestWarriorName = "Volkswagen";
        private const int TestWarriorDamage = 10;
        private const int TestWarriorHP = 50;

        private const string WhiteSpace = " ";

        private const int MinAttackHP = 30;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior(TestWarriorName, TestWarriorDamage, TestWarriorHP);
        }

        [TearDown]
        public void TearDown()
        {
            warrior = null;
        }

        [Test]
        public void CreateWarrior()
        {
            warrior = new Warrior(TestWarriorName, TestWarriorDamage, TestWarriorHP);

            Assert.That(warrior.Name, Is.EqualTo(TestWarriorName));
            Assert.That(warrior.Damage, Is.EqualTo(TestWarriorDamage));
            Assert.That(warrior.HP, Is.EqualTo(TestWarriorHP));
        }

        [Test]
        [TestCase(null)]
        [TestCase(WhiteSpace)]
        public void NameShouldThrowIfNullOrWhiteSpace(string name)
        {
            ArgumentException exeption = Assert
                .Throws<ArgumentException>(() => warrior = new Warrior(name, TestWarriorDamage, TestWarriorHP));

            Assert.That(exeption.Message, Is.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void DamageShouldThrowIfZeroOrNegative(int damage)
        {
            ArgumentException exeption = Assert
                .Throws<ArgumentException>(() => warrior = new Warrior(TestWarriorName, damage, TestWarriorHP));

            Assert.That(exeption.Message, Is.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void HPShouldThrowIfLessThanZero()
        {
            ArgumentException exeption = Assert
                .Throws<ArgumentException>(() => warrior = new Warrior(TestWarriorName, TestWarriorDamage, -1));

            Assert.That(exeption.Message, Is.EqualTo("HP should not be negative!"));
        }

        [Test]
        public void AttackMethodShouldThrowIfAttackerHPIsLessThanMinAttackHP()
        {
            var attacker = new Warrior("a1", 15, MinAttackHP - 1);
            var enemy = new Warrior("d1", 10, 40);

            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => attacker.Attack(enemy));

            Assert.That(exeption.Message, Is.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void AttackMethodShouldThrowIfDefenderHPIsLessThanMinAttackHP()
        {
            var attacker = new Warrior("a1", 15, 40);
            var enemy = new Warrior("d1", 10, MinAttackHP - 1);

            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => attacker.Attack(enemy));

            Assert.That(exeption.Message, Is.EqualTo($"Enemy HP must be greater than {MinAttackHP} in order to attack him!"));
        }

        [Test]
        public void AttackMethodShouldThrowIfAttackerHPIsLessThanEnemyDmg()
        {
            var attacker = new Warrior("a1", 15, MinAttackHP + 10);
            var enemy = new Warrior("d1", MinAttackHP + 20, MinAttackHP + 10);

            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => attacker.Attack(enemy));

            Assert.That(exeption.Message, Is.EqualTo("You are trying to attack too strong enemy"));
        }

        [Test]
        public void AttackShouldSucceed()
        {
            var enemy = new Warrior("e1", 10, 35);

            warrior.Attack(enemy);

            // 10, 50
            Assert.That(warrior.HP, Is.EqualTo(40));
            Assert.That(enemy.HP, Is.EqualTo(25));
        }

        [Test]
        public void AttackShouldKill()
        {
            var attacker = new Warrior("a1", 45, 35);
            var enemy = new Warrior("e1", 15, 35);

            attacker.Attack(enemy);

            Assert.That(attacker.HP, Is.EqualTo(20));
            Assert.That(enemy.HP, Is.EqualTo(0));
        }
    }
}