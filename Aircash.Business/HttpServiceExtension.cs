using Aircash.Business.Settings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aircash.Business
{
    public static class HttpServiceExtension
    {
        public static void AddCustomHttpClient(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddHttpClient("AmadeusApi", client =>
            {
                client.BaseAddress = new Uri(appSettings.AmadeusApi.ApiUrl);
                client.Timeout = TimeSpan.FromSeconds(5);
            });
        }
    }
}
