using Microsoft.EntityFrameworkCore;
using MarketProject.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketProject.Data.Context
{
    public class MarketProjectDbContext : DbContext
    {
        public MarketProjectDbContext(DbContextOptions<MarketProjectDbContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}

