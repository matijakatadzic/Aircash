using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aircash.Repository.DataLayer.Models.IataCodes
{
    [Table("IATA", Schema = "IATACode")]
    public class IATA
    {
        [Key]
        public int ID { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [JsonProperty("iata_code")]
        public string Code { get; set; }
    }
}
