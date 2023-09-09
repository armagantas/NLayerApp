using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id); // Id is primary key
            builder.Property(x => x.Id).UseIdentityColumn(); // Id is identity column
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50); // Name is required and max length is 50
            builder.ToTable("Categories"); // Table name is Categories
        }
    }
}
