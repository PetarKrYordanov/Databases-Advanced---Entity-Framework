namespace CarDealership.Data
{
    using CarDealership.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.IsImporter)
                .HasDefaultValue(false);

            builder.HasMany(e => e.Parts)
                .WithOne(e => e.Supplier)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}