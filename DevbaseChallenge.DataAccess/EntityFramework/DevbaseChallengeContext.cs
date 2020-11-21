using DevbaseChallenge.Core.Entities;
using DevbaseChallenge.DataAccess.EntityFramework.Configuration;
using DevbaseChallenge.DataAccess.EntityFramework.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevbaseChallenge.DataAccess.EntityFramework
{
    public class DevbaseChallengeContext:DbContext
    {
        public DevbaseChallengeContext(DbContextOptions<DevbaseChallengeContext> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
         
            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2,3 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2,3}));
            
        }
    }
}
