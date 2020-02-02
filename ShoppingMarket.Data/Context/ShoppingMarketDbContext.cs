using Microsoft.EntityFrameworkCore;
using ShoppingMarket.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingMarket.Data.Context
{
    public class ShoppingMarketDbContext : DbContext
    {
        public ShoppingMarketDbContext(DbContextOptions<ShoppingMarketDbContext> options) : base(options)
        {
        
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Sales> Sales { get; set; }
    }
}
