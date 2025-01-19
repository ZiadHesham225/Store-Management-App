using E_commerce_V1.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce_V1.Configurations;

public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
{
    public void Configure(EntityTypeBuilder<OrderDetails> builder)
    {
        builder.HasOne(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.OrderId);

        builder.HasOne(od => od.Product)
            .WithMany()
            .HasForeignKey(od => od.ProductId);

        
        builder.Property(od => od.Quantity)
            .IsRequired();

        builder.Property(od => od.TotalPrice)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
    }
}