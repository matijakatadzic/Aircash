using System;
using System.Collections.Generic;
using System.Text;

namespace Aircash.Business.HttpClientService.ServiceHelpers
{
    public static class ServiceUrlHelper
    {
        public static string GetData() => $"hotel-offers?cityCode=PAR&roomQuantity=1&adults=2&radius=100&radiusUnit=KM&paymentPolicy=NONE&includeClosed=false&bestRateOnly=true&view=FULL&sort=NONE";
    }
}
