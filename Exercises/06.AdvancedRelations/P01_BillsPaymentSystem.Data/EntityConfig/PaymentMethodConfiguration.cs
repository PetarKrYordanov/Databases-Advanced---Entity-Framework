﻿namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;
    class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(e => e.Id);

            // unique constraint
            builder.HasIndex(e => new { e.UserId, e.BankAccountId, e.CreditCardId }).IsUnique();

            builder.HasOne(e => e.BankAccount)
            .WithOne(ba => ba.PaymentMethod)
            .HasForeignKey<PaymentMethod>(e => e.BankAccountId);

            builder.HasOne(e => e.CreditCard)
                .WithOne(cc => cc.PaymentMethod)
                .HasForeignKey<PaymentMethod>(e => e.CreditCardId);


        }
    }
}
