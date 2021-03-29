using System;
using System.Collections.Generic;
using System.Text;

namespace Aircash.DataContract.DTOs
{
    public class IataDTO
    {
        public string Country { get; set; }
        public IEnumerable<IataCityCodeDTO> IataCityCodeDTO { get; set; }
    }
}
