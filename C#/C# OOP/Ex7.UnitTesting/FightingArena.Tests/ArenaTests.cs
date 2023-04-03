using System;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [TearDown]
        public void TearDown()
        {
            arena = null;
        }

        [Test]
        public void CreateArena()
        {
            arena = new Arena();

            Assert.That(arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void EnrollAddingCorrectly()
        {
            arena.Enroll(new Warrior("w1", 10, 40));

            Assert.That(arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void EnrollShouldThrowIfNameIsNotUnique()
        {
            arena.Enroll(new Warrior("w1", 10, 40));

            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("w1", 111, 111)));

            Assert.That(exeption.Message, Is.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void FightShouldThrowIfDefenderIsMissing()
        {
            arena.Enroll(new Warrior("Pesho", 5, 12));

            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => arena.Fight("Pesho", "Gosho"));

            Assert.That(exeption.Message, Is.EqualTo("There is no fighter with name Gosho enrolled for the fights!"));
        }

        [Test]
        public void FightShouldThrowIfAttackerIsMissing()
        {
            arena.Enroll(new Warrior("Pesho", 5, 12));

            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => arena.Fight("Misho", "Pesho"));

            Assert.That(exeption.Message, Is.EqualTo("There is no fighter with name Misho enrolled for the fights!"));
        }

        [Test]
        public void TestFigth()
        {
            var attacker = new Warrior("Pesho", 15, 35);
            var defender = new Warrior("Gosho", 15, 45);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.That(attacker.HP, Is.EqualTo(20));
            Assert.That(defender.HP, Is.EqualTo(30));
        }
    }
}
