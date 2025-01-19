using E_commerce_V1.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce_V1.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(40);

        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Stock)
            .IsRequired();

        builder.HasData(
            new Product { Id = 1, Name = "Smartphone", Price = 500, Stock = 20, CategoryId = 1 },
            new Product { Id = 2, Name = "T-shirt", Price = 15, Stock = 50, CategoryId = 2 },
            new Product { Id = 3, Name = "Novel", Price = 10, Stock = 30, CategoryId = 3 }
        );
    }
}