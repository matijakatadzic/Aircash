using Aircash.Business.Settings;
using Aircash.Repository.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aircash.Repository
{
    public static class MainEntitiesServiceExtension
    {
        public static void AddMainEntities(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddDbContext<MainEntities>(options => options.UseSqlServer(appSettings.ConnectionString));
        }
    }
}
