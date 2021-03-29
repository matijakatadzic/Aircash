using Aircash.DataContract.DTOs;
using Aircash.DataContract.HotelResponse;
using Aircash.Repository.DataLayer.Models.Hotels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aircash.Repository.AutoMapper
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<Price, PriceResponse>()
                .ForMember(t => t.basePrice, opt => opt.MapFrom(t => t.BasePrice))
                .ForMember(t => t.currency, opt => opt.MapFrom(t => t.Currency))
                .ForMember(t => t.total, opt => opt.MapFrom(t => t.Total))
                .ReverseMap();

            CreateMap<Offer, OfferResponse>()
                .ForMember(t => t.checkInDate, opt => opt.MapFrom(t => t.CheckInDate))
                .ForMember(t => t.checkOutDate, opt => opt.MapFrom(t => t.CheckOutDate))
                .ForMember(t => t.rateCode, opt => opt.MapFrom(t => t.RateCode))
                .ForMember(t => t.price, opt => opt.MapFrom(t => t.Price))
                .ReverseMap();

            CreateMap<Description, DescriptionResponse>()
                .ForMember(t => t.lang, opt => opt.MapFrom(t => t.Lang))
                .ForMember(t => t.text, opt => opt.MapFrom(t => t.Text))
                .ReverseMap();

            CreateMap<AddressResponse, Address>()
                .ForMember(t => t.CityName, opt => opt.MapFrom(t => t.cityName))
                .ForMember(t => t.CountryCode, opt => opt.MapFrom(t => t.countryCode))
                .ForMember(t => t.PostalCode, opt => opt.MapFrom(t => t.postalCode))
                .ForMember(t => t.AddressLine, opt => opt.MapFrom(t => ToLine(t.lines)))

                .ReverseMap();

            CreateMap<Hotel, HotelResponse>()
                .ForMember(t => t.chainCode, opt => opt.MapFrom(t => t.ChainCode))
                .ForMember(t => t.cityCode, opt => opt.MapFrom(t => t.CityCode))
                .ForMember(t => t.address, opt => opt.MapFrom(t => t.Address))
                .ForMember(t => t.description, opt => opt.MapFrom(t => t.Description))
                .ForMember(t => t.hotelId, opt => opt.MapFrom(t => t.HotelId))
                .ForMember(t => t.latitude, opt => opt.MapFrom(t => t.Latitude))
                .ForMember(t => t.longitude, opt => opt.MapFrom(t => t.Longitude))
                .ForMember(t => t.name, otp => otp.MapFrom(t => t.Name))
                .ForMember(t => t.rating, otp => otp.MapFrom(t => t.Rating))
                .ForMember(t => t.type, otp => otp.MapFrom(t => t.Type))
                .ReverseMap();

            CreateMap<Hotel, HotelDTO>()
                .ForMember(t => t.Description, opt => opt.MapFrom(t => AddDescription(t.Description)))
                .ForMember(t => t.ID, opt => opt.MapFrom(t => t.ID))
                .ForMember(t => t.Stars, opt => opt.MapFrom(t => t.Rating))
                .ForMember(t => t.Price, opt => opt.MapFrom(t => AddMinPrice(t.Offers)));
        }

        private object AddMinPrice(ICollection<Offer> offers)
        {
            if(!offers.Any())
            {
                return "No offer for CheackIn and CheackOut dates";
            }
            var minPrice = offers.OrderBy(m => m.Price.Total).First();
            return $"{minPrice.Price.Total} {minPrice.Price.Currency}";
        }

        private object AddDescription(Description description)
        {
            return description != null ? description.Text : "";
        }

        private string ToLine(List<string> lines)
        {
            return string.Join(", ", lines.ToArray());
        }
    }
}
