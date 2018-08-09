using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data
{
    internal class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Name).IsUnique();

            builder.HasMany(e => e.TripsFrom)
                .WithOne(e => e.OriginStation)
                .HasForeignKey(e => e.OriginStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.TripsTo)
                .WithOne(e => e.DestinationStation)
                .HasForeignKey(e => e.DestinationStationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}