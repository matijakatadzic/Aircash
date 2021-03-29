using System;
using System.Collections.Generic;
using System.Text;

namespace Aircash.DataContract.DTOs
{
    public class HotelDTO
    {
        public int ID { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}
