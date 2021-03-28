using Aircash.Business.HttpClientService.ServiceHelpers;
using Aircash.DataContract.Settings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace Aircash.Business
{
    public static class HttpServiceExtension
    {
        public static void AddCustomHttpClient(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddHttpClient("AmadeusApi", client =>
            {
                client.BaseAddress = new Uri(appSettings.AmadeusApi.ApiUrl);
                client.Timeout = TimeSpan.FromSeconds(60);
                client.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            });
        }
    }

}
