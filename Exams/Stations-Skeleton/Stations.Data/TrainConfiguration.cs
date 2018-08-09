using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data
{
    internal class TrainConfiguration : IEntityTypeConfiguration<Train>
    {
        public void Configure(EntityTypeBuilder<Train> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.TrainNumber).IsUnique();

            builder.HasMany(e => e.Trips)
                .WithOne(e => e.Train)
                .HasForeignKey(e => e.TrainId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}