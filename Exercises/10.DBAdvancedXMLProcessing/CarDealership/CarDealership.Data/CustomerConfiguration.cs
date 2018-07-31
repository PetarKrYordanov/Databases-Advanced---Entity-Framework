namespace CarDealership.Data
{
using CarDealership.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.IsYoungDriver)
                .HasDefaultValue(false);

            builder.Property(e => e.Name)
                .HasMaxLength(30);

            builder.HasMany(e => e.Sales)
                .WithOne(e => e.Customer)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}