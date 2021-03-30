using System;
using System.Collections.Generic;
using System.Text;

namespace Aircash.Web.Business.HttpClientService.ServiceHelpers
{
    public class ServiceUrlHelper
    {
        internal static string GetIataCode() => "Iata/GetIataDataAsync";

        internal static string GetHotels() => "Hotel/GetHotelsAsync/{0}/{1}/{2}/1?available={3}";

    }
}
