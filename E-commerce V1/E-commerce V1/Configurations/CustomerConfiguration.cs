using E_commerce_V1.Models.Entities;
using E_commerce_V1.Models.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace E_commerce_V1.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.FirstName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(c => c.LastName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(c => c.Email)
        .IsRequired();

        builder.HasData(
            new Customer
            {
                Id = 1,
                FirstName = "Alice",
                LastName = "Smith",
                Email = "alice@example.com"
            },
            new Customer
            {
                Id = 2,
                FirstName = "Bob",
                LastName = "Johnson",
                Email = "bob@example.com"
            }
        );

        builder.OwnsOne(c => c.Address).HasData(
            new
            {
                CustomerId = 1,
                Street = "123 Elm St",
                City = "Springfield",
                State = "IL",
                ZipCode = "62701",
                Country = "US"
            },
            new
            {
                CustomerId = 2,
                Street = "456 Oak St",
                City = "Madison",
                State = "WI",
                ZipCode = "53703",
                Country = "US"
            }
        );

    }
}