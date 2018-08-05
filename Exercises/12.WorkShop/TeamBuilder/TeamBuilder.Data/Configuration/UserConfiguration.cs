using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Username).IsRequired();

            builder.Property(e => e.Password).IsRequired().HasMaxLength(30);

            builder.HasIndex(e => e.Username).IsUnique();

            builder.Property(e => e.LastName).HasMaxLength(25);

            builder.Property(e => e.FirstName).HasMaxLength(25);

            builder.HasMany(e => e.UserTeams)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.CreatedUserTeams)
                .WithOne(e => e.Creator)
                .HasForeignKey(e => e.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.RecievedInvitations)
                .WithOne(e => e.InvitedUser)
                .HasForeignKey(e => e.InvitedUserId)
                .OnDelete(DeleteBehavior.Restrict) ;

            builder.HasMany(e => e.CreatedEvents)
                .WithOne(e => e.Creator)
                .HasForeignKey(e => e.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
