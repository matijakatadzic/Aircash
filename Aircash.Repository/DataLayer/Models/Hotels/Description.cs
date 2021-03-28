using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aircash.Repository.DataLayer.Models.Hotels
{
    [Table("Description", Schema = "dbo")]
    public class Description
    {
        [Key]
        public int ID { get; set; }
        public string Lang { get; set; }
        public string Text { get; set; }
    }
}