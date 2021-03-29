using Aircash.Repository.DataLayer.Models.Hotels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aircash.Repository.DataLayer.Repository
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetHotelDataAsync(string cityCode, DateTime checkInDate, DateTime checkOutDate, int adults, bool available);
        Task SaveHotelsAsync(List<Hotel> mapHotel);
    }
}