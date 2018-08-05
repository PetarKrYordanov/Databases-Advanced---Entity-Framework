using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                         .IsRequired()
                         .HasMaxLength(25);

            builder.HasIndex(e => e.Name).IsUnique();

            builder.Property(e => e.Description).HasMaxLength(32);

            builder.Property(e => e.Acronym)
                .IsRequired()
                .HasMaxLength(3)
                .IsFixedLength(true);

            builder.HasMany(e => e.Invitations)
                .WithOne(e => e.Team)
                .HasForeignKey(e => e.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.UserTeams)
                .WithOne(e => e.Team)
                .HasForeignKey(e => e.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.EventTeams)
                .WithOne(e => e.Team)
                .HasForeignKey(e => e.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
