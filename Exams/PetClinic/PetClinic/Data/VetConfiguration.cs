using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.Models;

namespace PetClinic.Data
{
    internal class VetConfiguration : IEntityTypeConfiguration<Vet>
    {
        public void Configure(EntityTypeBuilder<Vet> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.Procedures)
                .WithOne(e => e.Vet)
                .HasForeignKey(e => e.VetId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}