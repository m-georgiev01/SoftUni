using System;
using System.Collections;
using System.Linq;
using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private IRepository<IHotel> hotels;

        public Controller()
        {
            hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (hotels.All().Any(h => h.FullName == hotelName))
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            IHotel hotel = new Hotel(hotelName, category);
            hotels.AddNew(hotel);

            return string.Format(OutputMessages.HotelSuccessfullyRegistered,category, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (!hotels.All().Any(h => h.FullName == hotelName))
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IHotel hotel = hotels.Select(hotelName);
            if (hotel.Rooms.All().Any(r => r.GetType().Name == roomTypeName))
            {
                return OutputMessages.RoomTypeAlreadyCreated;
            }

            if (!IsValidRoomType(roomTypeName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RoomTypeIncorrect, hotelName));
            }

            IRoom room = CreateRoom(roomTypeName);
            hotel.Rooms.AddNew(room);

            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }


        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (!hotels.All().Any(h => h.FullName == hotelName))
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (!IsValidRoomType(roomTypeName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RoomTypeIncorrect, hotelName));
            }

            IHotel hotel = hotels.Select(hotelName);
            if (!hotel.Rooms.All().Any(r => r.GetType().Name == roomTypeName))
            {
                return OutputMessages.RoomTypeNotCreated;
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }

            room.SetPrice(price);

            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (hotels.All().FirstOrDefault(h => h.Category == category) == null)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            IOrderedEnumerable<IHotel> orderedHotels = hotels
                .All()
                .Where(h => h.Category == category)
                .OrderBy(h => h.FullName);

            foreach (var hotel in orderedHotels)
            {
                IRoom room = hotel.Rooms
                    .All()
                    .Where(r => r.PricePerNight > 0)
                    .OrderBy(r => r.BedCapacity)
                    .FirstOrDefault(r => r.BedCapacity >= adults + children);

                if (room != null)
                {
                    int bookingNumber = hotel.Bookings.All().Count() + 1;

                    IBooking booking = new Booking(room, duration, adults, children, bookingNumber);

                    hotel.Bookings.AddNew(booking);

                    return string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName);
                }
            }

            return OutputMessages.RoomNotAppropriate;
        }


        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            StringBuilder sb = new();

            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();

            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                    sb.AppendLine();
                }
            }

            return sb.ToString().TrimEnd();
        }

        private bool IsValidRoomType(string roomTypeName)
            => roomTypeName == nameof(Apartment) ||
               roomTypeName == nameof(DoubleBed) ||
               roomTypeName == nameof(Studio);

        private IRoom CreateRoom(string roomTypeName)
        {
            IRoom room = null;

            if (roomTypeName == nameof(Apartment))
            {
                room = new Apartment();
            }
            if (roomTypeName == nameof(DoubleBed))
            {
                room = new DoubleBed();
            }
            if (roomTypeName == nameof(Studio))
            {
                room = new Studio();
            }

            return room;
        }
    }
}
