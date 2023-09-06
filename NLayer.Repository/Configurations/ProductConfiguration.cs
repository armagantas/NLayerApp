using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id); // Id is primary key

            builder.Property(x => x.Id).UseIdentityColumn(); // Id is identity column

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200); // Name is required and max length is 200

            builder.Property(x => x.Stock).IsRequired(); // Stock is required

            builder.Property(x=> x.Price).IsRequired().HasColumnType("decimal(18,2)"); // Price is required and type is decimal(18,2)

            builder.ToTable("Products"); // Table name is Products

            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId); // Product has one category and category has many products
        }
    }
}
