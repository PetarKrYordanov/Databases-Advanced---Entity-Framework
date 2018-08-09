using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data
{
    internal class CustomerCardConfiguration : IEntityTypeConfiguration<CustomerCard>
    {
        public void Configure(EntityTypeBuilder<CustomerCard> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.BoughtTickets)
                 .WithOne(e => e.CustomerCard)
                 .HasForeignKey(e => e.CustomerCardId)
                 .OnDelete(DeleteBehavior.SetNull);
        }
    }
}