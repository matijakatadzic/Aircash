using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aircash.Repository.DataLayer.Models.Hotels
{
    [Table("Address", Schema = "dbo")]
    public class Address
    {
        [Key]
        public int ID { get; set; }
        public string PostalCode { get; set; }
        public string CityName { get; set; }
        public string CountryCode { get; set; }
    }
}