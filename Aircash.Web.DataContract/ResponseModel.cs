using System;
using System.Collections.Generic;
using System.Text;

namespace Aircash.Web.DataContract
{
    public class ResponseModel<TValue>
    {
        public string ErrorMsg { get; set; }
        public TValue Value { get; set; }
    }
}
