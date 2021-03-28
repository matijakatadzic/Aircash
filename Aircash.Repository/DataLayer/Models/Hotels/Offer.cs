using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aircash.Repository.DataLayer.Models.Hotels
{
    [Table("Offer", Schema = "dbo")]
    public class Offer
    {
        [Key]
        public int ID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string RateCode { get; set; }
        public Price Price { get; set; }
    }
}