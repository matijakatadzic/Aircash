using Aircash.Web;
using Aircash.Web.DataContract.Settings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace Aircash.Web
{
    public static class HttpServiceExtension
    {
        public static void AddCustomHttpClient(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddHttpClient("Api", client =>
            {
                client.BaseAddress = new Uri(appSettings.ApiUrl);
                client.Timeout = TimeSpan.FromSeconds(60);
                client.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
        }
    }

}
