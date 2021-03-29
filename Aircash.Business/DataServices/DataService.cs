using Aircash.Business.HttpClientService;
using Aircash.DataContract;
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

        public async Task<ResponseModel<IEnumerable<Hotel>>> GetHotelDataAsync(string cityCode, DateTime checkInDate, DateTime checkOutDate, int adults, bool available)
        {
            IEnumerable<Hotel> hotels;

            hotels = await _hotelRepository.GetHotelDataAsync(cityCode, checkInDate,checkOutDate, adults, available);

            if(hotels.Count() == 0)
            {
                var hotelResponse = await _amadeusHotelHttpClientService.GetHotelDataAsync(cityCode, checkInDate, checkOutDate, adults, available);

                if(!string.IsNullOrEmpty(hotelResponse.ErrorMsg))
                {
                    return new ResponseModel<IEnumerable<Hotel>> { ErrorMsg = hotelResponse.ErrorMsg };
                }

                List<Hotel> mapHotel = new List<Hotel>();

                foreach (var item in hotelResponse.Value.data)
                {
                   var hotel = _mapper.Map<HotelResponse, Hotel>(item.hotel);
                    hotel.Offers = _mapper.Map<IEnumerable<OfferResponse>, IEnumerable<Offer>>(item.offers).ToList();
                    hotel.Available = item.available;
                    mapHotel.Add(hotel);
                }

                await _hotelRepository.SaveHotelsAsync(mapHotel);

                hotels = mapHotel;
            }

            return new ResponseModel<IEnumerable<Hotel>> { Value = hotels};
        }
    }
}
