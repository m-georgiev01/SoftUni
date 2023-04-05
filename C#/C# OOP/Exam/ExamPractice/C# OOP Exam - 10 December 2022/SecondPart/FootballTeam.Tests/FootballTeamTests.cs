using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballTeam team;
        private const string Name = "Botev Plovdiv";
        private const int Capacity = 21;

        [SetUp]
        public void Setup()
        {
            team = new FootballTeam(Name, Capacity);
        }

        [TearDown]
        public void TearDown()
        {
            team = null;
        }

        [Test]
        public void FootballTeamCreateSuccessfully()
        {
            team = new FootballTeam(Name, Capacity);

            Assert.That(team.Name, Is.EqualTo(Name));
            Assert.That(team.Capacity, Is.EqualTo(Capacity));
            Assert.That(team.Players.Count, Is.EqualTo(0));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void NameSetterShouldThrowIfNullOrEmpty(string name)
        {
            ArgumentException exception =
                Assert.Throws<ArgumentException>(() => team = new FootballTeam(name, Capacity));

            Assert.That(exception.Message, Is.EqualTo("Name cannot be null or empty!"));
        }

        [Test]
        [TestCase(14)]
        [TestCase(0)]
        [TestCase(-14)]
        public void CapacitySetterShouldThrowIfLessThan15(int capacity)
        {
            ArgumentException exception =
                Assert.Throws<ArgumentException>(() => team = new FootballTeam(Name, capacity));

            Assert.That(exception.Message, Is.EqualTo("Capacity min value = 15"));
        }

        [Test]
        public void PlayersReturnCorrectly()
        {
            FootballPlayer p1 = new FootballPlayer("Pesho", 1, "Goalkeeper");
            team.AddNewPlayer(p1);

            List<FootballPlayer> expected = new List<FootballPlayer>();
            expected.Add(p1);

            Assert.That(team.Players, Is.EquivalentTo(expected));
        }

        [Test]
        public void AddNewPlayerShouldThrowIfAddingMoreThanCapacity()
        {
            for (int i = 1; i <= Capacity; i++)
            {
                team.AddNewPlayer(new FootballPlayer(i.ToString(), i, "Goalkeeper"));
            }

            string expected = team.AddNewPlayer(new FootballPlayer("1", 1, "Forward"));

            Assert.That(expected, Is.EqualTo("No more positions available!"));
        }

        [Test]
        public void AddNewPlayerAddingSuccessfully()
        {
            FootballPlayer p1 = new FootballPlayer("Pesho", 7, "Forward");

            string expectedOutput = team.AddNewPlayer(p1);

            Assert.That(team.Players.Count, Is.EqualTo(1));
            Assert.That(team.Players[0].Name, Is.EqualTo(p1.Name));
            Assert.That(team.Players[0].PlayerNumber, Is.EqualTo(p1.PlayerNumber));
            Assert.That(team.Players[0].Position, Is.EqualTo(p1.Position));
            Assert.That(expectedOutput, Is.EqualTo($"Added player {p1.Name} in position {p1.Position} with number {p1.PlayerNumber}"));
        }

        [Test] public void PickPlayerReturnsCorrectPlayer()
        {
            FootballPlayer p1 = new FootballPlayer("Pesho", 7, "Forward");
            FootballPlayer p2 = new FootballPlayer("Gosho", 3, "Goalkeeper");

            team.AddNewPlayer(p1);
            team.AddNewPlayer(p2);

            FootballPlayer player = team.PickPlayer("Gosho");

            Assert.That(player, Is.Not.Null);
            Assert.That(player.Name, Is.EqualTo(p2.Name));
            Assert.That(player.PlayerNumber, Is.EqualTo(p2.PlayerNumber));
            Assert.That(player.Position, Is.EqualTo(p2.Position));
        }

        [Test]
        public void PickPlayerReturnsNullIfThereIsNoMatch()
        {
            FootballPlayer p1 = new FootballPlayer("Pesho", 7, "Forward");
            FootballPlayer p2 = new FootballPlayer("Gosho", 3, "Goalkeeper");

            team.AddNewPlayer(p1);
            team.AddNewPlayer(p2);

            FootballPlayer player = team.PickPlayer("Marto");

            Assert.That(player, Is.Null);
        }

        [Test]
        public void PlayerScoreThrowsIfPlayerIsNotFound()
        {
            Assert.Throws<NullReferenceException>(() => team.PlayerScore(1));
        }

        [Test]
        public void PlayerScoreReturnsCorrectMessageIfPlayerIsFound()
        {
            FootballPlayer p1 = new FootballPlayer("Pesho", 7, "Forward");
            team.AddNewPlayer(p1);
            string actual = team.PlayerScore(p1.PlayerNumber);

            string expected = $"{p1.Name} scored and now has {p1.ScoredGoals} for this season!";

            Assert.That(expected, Is.EqualTo(actual));
            Assert.That(p1.ScoredGoals, Is.EqualTo(1));
        }
    }
}