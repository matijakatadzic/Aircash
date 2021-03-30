using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Aircash.Web.Business.HttpClientService;

namespace Aircash.Web.Business
{
    public static class BusinessServiceExtension
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<IApiService, ApiService>();
        }
    }
}
