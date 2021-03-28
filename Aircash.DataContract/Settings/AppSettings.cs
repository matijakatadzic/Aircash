using System;
using System.Collections.Generic;
using System.Text;

namespace Aircash.DataContract.Settings
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public AmadeusApi AmadeusApi { get; set; }
        public SwaggerOptions SwaggerOptions { get; set; }
    }
}
