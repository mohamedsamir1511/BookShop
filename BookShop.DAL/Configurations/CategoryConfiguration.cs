using BookShop.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BookShop.DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Table and Schema
            //builder.ToTable("Categories","MasterSchema");//should have relational package manager 
            builder.ToTable("Categories","MasterSchema");
            
            // Primary Key
            builder.HasKey(k => k.Id);

            // CatName - Required + MaxLength
            builder.Property(c => c.CatName)
                   .IsRequired()
                   .HasMaxLength(50);

            // CatOrder - Required
            builder.Property(c => c.CatOrder)
                   .IsRequired();

            // Ignore CreatedDate (NotMapped)
            builder.Ignore(c => c.CreatedDate);

            // Change column name for MarkedAsDeleted to IsDeleted
            //builder.Property(c => c.MarkedAsDeleted)
            //.HasColumnName("isDeleted");// should also relational package
            builder.Property(c => c.MarkedAsDeleted).HasColumnName("IsDeleted");
        }
    }
}
