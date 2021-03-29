using Aircash.Repository.DataLayer.Models.Hotels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aircash.Repository.DataLayer
{
    public class MainEntities : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Offer> Offers { get; set; }

        public MainEntities(DbContextOptions<MainEntities> options)
            : base(options)
        {
        }
    }
}
