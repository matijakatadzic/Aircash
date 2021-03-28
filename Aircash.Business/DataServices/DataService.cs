using Aircash.Business.HttpClientService;
using Aircash.DataContract.HotelResponse;
using Aircash.Repository.DataLayer.Models.Hotels;
using Aircash.Repository.DataLayer.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aircash.Business.DataServices
{
    public class DataService : IDataService
    {
        private IAmadeusHotelHttpClientService _amadeusHotelHttpClientService;
        private IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public DataService(IAmadeusHotelHttpClientService amadeusHotelHttpClientService, IHotelRepository hotelRepository, IMapper mapper)
        {
            _amadeusHotelHttpClientService = amadeusHotelHttpClientService;
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Hotel>> GetHotelDataAsync(string cityCode, DateTime checkInDate, DateTime checkOutDate, int adults)
        {
            IEnumerable<Hotel> hotels;

            hotels = await _hotelRepository.GetHotelDataAsync(cityCode, checkInDate,checkOutDate, adults);

            if(hotels.Count() == 0)
            {
                var hotelResponse = await _amadeusHotelHttpClientService.GetHotelDataAsync(cityCode, checkInDate, checkOutDate, adults);

                List<Hotel> mapHotel = new List<Hotel>();

                foreach (var item in hotelResponse.data)
                {
                   var hotel = _mapper.Map<HotelResponse, Hotel>(item.hotel);
                    mapHotel.Add(hotel);
                }

                await _hotelRepository.SaveHotelsAsync(mapHotel);
                return mapHotel;
            }

            return hotels;
        }
    }
}
