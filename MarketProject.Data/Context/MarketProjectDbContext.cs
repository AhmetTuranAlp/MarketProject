using Microsoft.EntityFrameworkCore;
using MarketProject.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketProject.Data.Context
{
    public class MarketProjectDbContext : DbContext
    {
        public MarketProjectDbContext(DbContextOptions<MarketProjectDbContext> options): base(options)
        { }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

