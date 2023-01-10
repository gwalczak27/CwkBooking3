using CwkBooking3.Domain.Models;
using System.Collections.Generic;

namespace CwkBooking3.API.Services
{
    public class MyFirstService
    {
        public readonly DataSource _dataSource;
        public MyFirstService(DataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public List<Hotel> GetHotels()
        {
            return _dataSource.Hotels;
        }
    }
}
