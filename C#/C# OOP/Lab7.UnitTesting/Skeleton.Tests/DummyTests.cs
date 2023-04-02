using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private const int Health = 5;
        private const int Experience = 10;
        private const int EnemyAttackPoints = 5;

        [SetUp]
        public void SetUp()
        {
            dummy = new(Health, Experience);
        }

        [Test]
        public void DummyLosesHealthOnAttack()
        {
            dummy.TakeAttack(EnemyAttackPoints);
            int expected = 0;

            Assert.That(dummy.Health, Is.EqualTo(expected), "Dummy isn't losing HP correctly!");
        }

        [Test]
        public void DeadDummyThrowsIOExceptionIfAttacked()
        {
            dummy.TakeAttack(EnemyAttackPoints);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(EnemyAttackPoints), "Dead dummy can't take more damage!");
        }

        [Test]
        public void DeadDummyGivesExp()
        {
            dummy.TakeAttack(EnemyAttackPoints);

            int expected = 10;

            Assert.That(dummy.GiveExperience(), Is.EqualTo(expected));
        }

        [Test]
        public void AliveDummyCantGiveExp()
        {
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Only dead dummies can give exp!");
        }
    }
}