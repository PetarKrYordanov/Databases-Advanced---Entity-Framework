using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.Models;

namespace PetClinic.Data
{
    internal class ProcedureAnimalAidsConfiguration : IEntityTypeConfiguration<ProcedureAnimalAid>
    {
        public void Configure(EntityTypeBuilder<ProcedureAnimalAid> builder)
        {
            builder.HasKey(e => new { e.AnimalAidId, e.ProcedureId });

            builder.HasOne(e => e.AnimalAid)
                .WithMany(e => e.AnimalAidProcedures)
                .HasForeignKey(e => e.AnimalAidId)
                .OnDelete(DeleteBehavior.Restrict) ;

            builder.HasOne(e => e.Procedure)
                .WithMany(e => e.ProcedureAnimalAids)
                .HasForeignKey(e => e.ProcedureId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}