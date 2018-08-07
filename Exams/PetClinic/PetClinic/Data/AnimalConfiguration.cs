using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.Models;

namespace PetClinic.Data
{
    internal class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.Procedures)
                .WithOne(w => w.Animal)
                .HasForeignKey(e => e.AnimalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Passport)
                .WithOne(e => e.Animal)
                .HasForeignKey<Animal>(e => e.PassportSerialNumber)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}