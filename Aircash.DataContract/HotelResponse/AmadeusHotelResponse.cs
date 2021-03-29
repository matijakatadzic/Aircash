using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aircash.DataContract.HotelResponse
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    [JsonObject("Address")]
    public class AddressResponse
    {
        public List<string> lines { get; set; }
        public string postalCode { get; set; }
        public string cityName { get; set; }
        public string countryCode { get; set; }
    }

    [JsonObject("Description")]
    public class DescriptionResponse
    {
        public string lang { get; set; }
        public string text { get; set; }
    }

    [JsonObject("Hotel")]
    public class HotelResponse
    {
        public string type { get; set; }
        public string hotelId { get; set; }
        public string chainCode { get; set; }
        public string name { get; set; }
        public string rating { get; set; }
        public string cityCode { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        [JsonProperty("address")]
        public AddressResponse address { get; set; }
        [JsonProperty("description")]
        public DescriptionResponse description { get; set; }
    }
    [JsonObject("Price")]
    public class PriceResponse
    {
        public string currency { get; set; }
        [JsonProperty("base")]
        public string basePrice { get; set; }
        public string total { get; set; }
    }

    [JsonObject("Offer")]
    public class OfferResponse
    {
        public string checkInDate { get; set; }
        public string checkOutDate { get; set; }
        public string rateCode { get; set; }
        [JsonProperty("price")]
        public PriceResponse price { get; set; }
    }

    public class Data
    {
        [JsonProperty("hotel")]
        public HotelResponse hotel { get; set; }
        public bool available { get; set; }
        [JsonProperty("offers")]
        public List<OfferResponse> offers { get; set; }
    }

    [JsonObject("Root")]
    public class AmadeusHotelResponse
    {
        public List<Data> data { get; set; }
    }


}
