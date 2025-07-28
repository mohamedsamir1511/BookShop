using BookShop.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.ToTable("Products", "MasterSchema"); 
            builder.HasKey(x => x.Id);

            builder.Property(c=>c.Title).IsRequired().HasMaxLength(50);

            builder.Property(d=>d.Description).HasMaxLength(250).IsRequired(false);

            builder.Property(a=>a.Author).HasMaxLength(50).IsRequired();

            builder.Property(p => p.Price).HasColumnName("BookPrice").IsRequired();

            builder.HasCheckConstraint ("CK_Products_BookPrice_Range","[BookPrice] BETWEEN 1 AND 1000");

            builder.HasOne(p=>p.Category).WithMany(c=>c.Products).HasForeignKey(p=>p.CategoryId);


            
        }
    }
}
