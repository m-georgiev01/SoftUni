using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        const int axeDmg = 5;
        const int axeDurability = 1;
        const int dummyHealth = 10;
        const int dummyExp = 10;

        Axe axe;
        Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new(axeDmg, axeDurability);
            dummy = new(dummyHealth, dummyExp);
        }


        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);

            int expected = 0;

            Assert.That(axe.DurabilityPoints, Is.EqualTo(expected), "Axe doesn't lose durability points correctly on attack!");
        }

        [Test]
        public void BrokenAxeShouldThrowIOExceptionOnAttack()
        {
            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}