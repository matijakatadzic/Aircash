using Aircash.Repository.DataLayer.Models.Hotels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aircash.Business.DataServices
{
    public interface IDataService
    {
        Task<IEnumerable<Hotel>> GetHotelDataAsync(string cityCode, DateTime checkInDate, DateTime checkOutDate, int adults);
    }
}