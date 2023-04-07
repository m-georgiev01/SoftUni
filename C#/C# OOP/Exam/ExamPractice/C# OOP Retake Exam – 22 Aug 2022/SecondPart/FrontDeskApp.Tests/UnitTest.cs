using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel hotel;

        [SetUp]
        public void Setup()
        {
            hotel = new Hotel("h1", 1);
        }

        [TearDown]
        public void TearDown()
        {
            hotel = null;
        }

        [Test]
        public void HotelCreateSuccessfully()
        {
            hotel = new Hotel("h1", 1);

            Assert.That(hotel.FullName, Is.EqualTo("h1"));
            Assert.That(hotel.Category, Is.EqualTo(1));
            Assert.That(hotel.Rooms.Count, Is.EqualTo(0));
            Assert.That(hotel.Bookings.Count, Is.EqualTo(0));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void FullNameSetterThrowsIfNullOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(name, 1));
        }

        [Test]
        [TestCase(0)]
        [TestCase(6)]
        public void CategorySetterThrowsIfNotBetweenOneAndFive(int category)
        {
            Assert.Throws<ArgumentException>(() => new Hotel("h1", category));
        }

        [Test]
        public void AddRoomWorksCorrectly()
        {
            Room room = new Room(1, 10);
            hotel.AddRoom(room);

            var expected = new List<Room>();
            expected.Add(room);

            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
            Assert.That(hotel.Rooms, Is.EquivalentTo(expected));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void BookRoomThrowsIfAdultsLessThanOne(int adults)
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(adults, 1, 1, 10));
        }

        [Test]
        public void BookRoomThrowsIfChildrenLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, -1, 1, 10));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void BookRoomThrowsIfDurationLessThanOne(int duration)
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, 0, duration, 10));
        }

        [Test]
        public void BookRoomDoesNotBookIfNoRoomIsFound()
        {
            Room room = new Room(1, 10);
            hotel.AddRoom(room);

            hotel.BookRoom(2, 0, 1, 11);

            Assert.That(hotel.Bookings.Count, Is.EqualTo(0));
            Assert.That(hotel.Turnover, Is.EqualTo(0));
        }

        [Test]
        public void BookRoomWorksCorrectly()
        {
            Room room = new Room(2, 10);
            double expectedTurnover = 1 * 10;
            hotel.AddRoom(room);

            hotel.BookRoom(2, 0, 1, 11);

            Assert.That(hotel.Bookings.Count, Is.EqualTo(1));
            Assert.That(hotel.Turnover, Is.EqualTo(expectedTurnover));
        }
    }
}