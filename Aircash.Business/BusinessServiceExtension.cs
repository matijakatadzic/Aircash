using Aircash.Business.DataServices;
using Aircash.Business.HttpClientService;
using Aircash.Business.HttpClientService.ServiceHelpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aircash.Business
{
    public static class BusinessServiceExtension
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            
            services.AddScoped<IDataService, DataService>();

            services.AddScoped<IAmadeusHotelHttpClientService, AmadeusHotelHttpClientService>();

            services.AddSingleton<IOathTokenService, OathTokenService>();

        }
    }
}
