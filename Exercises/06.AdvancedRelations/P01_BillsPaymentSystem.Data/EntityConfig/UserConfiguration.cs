namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.HasMany(e => e.PaymentMethods)                
                .WithOne(d => d.User)
                .HasForeignKey(d => d.UserId);            
        }
    }
}
