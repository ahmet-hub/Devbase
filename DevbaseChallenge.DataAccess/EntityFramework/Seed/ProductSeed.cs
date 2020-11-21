using DevbaseChallenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevbaseChallenge.DataAccess.EntityFramework.Seed
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;

        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product { Id = 1, Name = "Samsung S10 Plus ", Price = 5.600m, Stock = 10, CategoryId = _ids[0] });
            builder.HasData(new Product { Id = 2, Name = "Iphone X  ", Price = 5.600m, Stock = 7, CategoryId = _ids[0] });
            builder.HasData(new Product { Id = 3, Name = "Xioami Not 10 Plus", Price = 3.505m, Stock = 16, CategoryId = _ids[0] });
            builder.HasData(new Product { Id = 4, Name = "Samsung 56 Inc Tv", Price = 4.550m, Stock = 10, CategoryId = _ids[1] });
            builder.HasData(new Product { Id = 5, Name = "Xioami 48 Inc Tv", Price = 3.550m, Stock = 30, CategoryId = _ids[1] });
            builder.HasData(new Product { Id = 6, Name = "Asus Laptop", Price = 13.550m, Stock = 10, CategoryId = _ids[2] });
            builder.HasData(new Product { Id = 7, Name = "Monster Laptop ", Price = 7.500m, Stock = 30, CategoryId = _ids[2] });
            builder.HasData(new Product { Id = 8, Name = "Msi Laptop ", Price = 10.500m, Stock = 20, CategoryId = _ids[2] });


        }
    }
}
