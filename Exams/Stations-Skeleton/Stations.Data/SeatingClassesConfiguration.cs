using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data
{
    public class SeatingClassesConfiguration : IEntityTypeConfiguration<SeatingClass>
    {
        public void Configure(EntityTypeBuilder<SeatingClass> builder)
        {

            builder.HasKey(e => e.Id);

            builder.HasAlternateKey(e => e.Name);

            builder.HasAlternateKey(e => e.Abbreviation);

            builder.HasMany(e => e.TrainSeats)
                .WithOne(e => e.SeatingClass)
                .HasForeignKey(e => e.SeatingClassId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}