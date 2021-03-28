using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aircash.Repository.DataLayer.Models.Hotels
{
    [Table("Price", Schema = "dbo")]
    public class Price
    {
        [Key]
        public int ID { get; set; }
        public string Currency { get; set; }
        public string BasePrice { get; set; }
        public string Total { get; set; }
    }
}