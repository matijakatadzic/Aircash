using Aircash.Repository.DataLayer.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aircash.Repository
{
    public static class RepositoryServiceExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            //Add your repositories here...
            services.AddTransient<IHotelRepository, HotelRepository>();
            services.AddTransient<IIataRepository, IataRepository>();

        }
    }
}
