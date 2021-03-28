using Aircash.DataContract.HotelResponse;
using System;
using System.Threading.Tasks;

namespace Aircash.Business.HttpClientService
{
    public interface IAmadeusHotelHttpClientService
    {
        Task<AmadeusHotelResponse> GetHotelDataAsync(string cityCode, DateTime checkInDate, DateTime checkOutDate, int adults);
    }
}