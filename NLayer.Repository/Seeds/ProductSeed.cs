using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1,
                Name =  "Faber Castel 2B",
                Stock = 100,
                Price = 12,
                CategoryId = 1,
                CreatedDate = DateTime.Now,
            }, new Product
            {
                Id = 2,
                Name = "Faber Castel 3B",
                Stock = 75,
                Price = 15,
                CategoryId = 1,
                CreatedDate = DateTime.Now,
            }, new Product
            {
                Id= 3,
                Name = "Book 1",
                Stock = 50,
                Price = 20,
                CategoryId = 2,
                CreatedDate = DateTime.Now,
            }, new Product
            {
                Id = 4,
                Name = "Book 2",
                Stock = 25,
                Price = 25,
                CategoryId = 2,
                CreatedDate = DateTime.Now,
            });
        }
    }
}
