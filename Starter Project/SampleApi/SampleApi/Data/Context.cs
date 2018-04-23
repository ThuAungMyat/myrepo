using SampleApi.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SampleApi.Data
{
    public class Context: DbContext
    {
        public Context() : base("name=SampleDB")
        {
            Database.SetInitializer<Context>(null);
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        modelBuilder.Entity<Artist>().HasKey<int>(e => e.ID);
        modelBuilder.Entity<Album>().HasKey<int>(e => e.ID);
        }
    }
}