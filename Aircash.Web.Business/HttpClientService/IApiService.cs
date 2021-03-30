using Aircash.Web.DataContract;
using Aircash.Web.DataContract.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aircash.Web.Business.HttpClientService
{
    public interface IApiService
    {
        Task<ResponseModel<IEnumerable<IataDTO>>> GetIataCodeAsync();
        Task<ResponseModel<IEnumerable<HotelDTO>>> GetHotelsAndOffersAsync(string iataSelect, DateTime checkIn, DateTime checkOut, int adult, bool available);
    }
}