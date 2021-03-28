using Aircash.DataContract.HotelResponse;
using Aircash.Repository.DataLayer.Models.Hotels;
using AutoMapper;
using System;
using System.Collections.Generic;
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

            CreateMap<Address, AddressResponse>()
                .ForMember(t => t.cityName, opt => opt.MapFrom(t => t.CityName))
                .ForMember(t => t.countryCode, opt => opt.MapFrom(t => t.CountryCode))
                .ForMember(t => t.postalCode, opt => opt.MapFrom(t => t.PostalCode))
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
        }
    }
}
