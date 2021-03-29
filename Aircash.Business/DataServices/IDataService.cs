using Aircash.DataContract;
using Aircash.Repository.DataLayer.Models.Hotels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aircash.Business.DataServices
{
    public interface IDataService
    {
        Task<ResponseModel<IEnumerable<Hotel>>> GetHotelDataAsync(string cityCode, DateTime checkInDate, DateTime checkOutDate, int adults, bool available);
    }
}