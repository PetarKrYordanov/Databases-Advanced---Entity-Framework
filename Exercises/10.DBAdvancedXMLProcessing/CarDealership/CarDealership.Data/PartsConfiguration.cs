namespace CarDealership.Data
{
    using CarDealership.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PartsConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired();

            builder.HasMany(e => e.PartCars)
                .WithOne(e => e.Part)
                .HasForeignKey(e => e.PartId)
                .OnDelete(DeleteBehavior.Restrict);
              
        }
    }
}