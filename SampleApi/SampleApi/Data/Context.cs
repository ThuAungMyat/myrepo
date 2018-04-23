using SampleApi.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SampleApi.Data
{
    public class Context : DbContext
    {
        public Context() : base("name=SampeDB")
        {
            Database.SetInitializer<Context>(null);
        }

        public DbSet<tbOrder> tbOrders { get; set; }
        public DbSet<tbOrderDetail> tbOrderDetails { get; set; }
        public DbSet<tbInventory> tbInventorys { get; set; }
        public DbSet<tbStock> tbStocks { get; set; }
        public DbSet<tbItem> tbItems { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Artist>().HasKey<int>(e => e.ID);
            modelBuilder.Entity<Album>().HasKey<int>(e => e.ID);
            modelBuilder.Entity<tbStock>().HasKey<int>(e => e.ID);
            modelBuilder.Entity<tbInventory>().HasKey<int>(e => e.ID);
            modelBuilder.Entity<tbOrder>().HasKey<int>(e => e.ID);
            modelBuilder.Entity<tbOrderDetail>().HasKey<int>(e => e.ID);
            modelBuilder.Entity<tbItem>().HasKey<int>(e => e.ID);

        }
    }
}