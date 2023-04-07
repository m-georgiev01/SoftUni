﻿using System.Collections.Generic;
using System.Linq;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> hotels;

        public HotelRepository()
        {
            hotels = new List<IHotel>();
        }

        public void AddNew(IHotel model)
            => hotels.Add(model);

        public IHotel Select(string criteria)
            => hotels.FirstOrDefault(h => h.FullName == criteria);

        public IReadOnlyCollection<IHotel> All()
            => hotels.AsReadOnly();
    }
}
