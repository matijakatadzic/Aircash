using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aircash.Repository.DataLayer
{
    public class MainEntities : DbContext
    {
        public MainEntities(DbContextOptions<MainEntities> options)
            : base(options)
        {
        }
    }
}
