using System;
using System.Collections.Generic;
using System.Text;

namespace Aircash.Business.HttpClientService.ServiceHelpers
{
    public static class ServiceUrlHelper
    {
        public static string GetData() => "hotel-offers?cityCode={0}&checkInDate={1}&checkOutDate={2}&roomQuantity=1&adults={3}&radius=100&radiusUnit=KM&paymentPolicy=NONE&includeClosed={4}&bestRateOnly=false&view=FULL&sort=NONE";
    }
}
