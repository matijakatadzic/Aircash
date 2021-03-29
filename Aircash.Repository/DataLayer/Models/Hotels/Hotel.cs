using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aircash.Repository.DataLayer.Models.Hotels
{
    [Table("Hotel", Schema = "dbo")]
    public class Hotel
    {
        [Key]
        public int ID { get; set; }
        public string Type { get; set; }
        public string HotelId { get; set; }
        public string ChainCode { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public string CityCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Address Address { get; set; }
        public Description Description { get; set; }
        public bool Available { get; set; }
        public ICollection<Offer> Offers { get; set; }
    }
}
