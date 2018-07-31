namespace CarDealership.Data
{
using CarDealership.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class CarsConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Model)
                .IsRequired();

            builder.HasMany(e => e.CarParts)
                .WithOne(e => e.Car)
                .HasForeignKey(e => e.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Sales)
                .WithOne(e => e.Car)
                .HasForeignKey(e => e.CarId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}