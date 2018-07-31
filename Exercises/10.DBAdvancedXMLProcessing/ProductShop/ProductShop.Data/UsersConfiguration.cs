namespace ProductShop.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ProductShop.Models;

    internal class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.LastName).IsRequired();

            builder.HasMany(e => e.BoughtProduct)
                .WithOne(d => d.Buyer)
                .HasForeignKey(d => d.BuyerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.SoldProducts)
                .WithOne(d => d.Seller)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.FriendsUsers)
                .WithOne(d => d.Friend)
                .HasForeignKey(d => d.FriendId)
                .OnDelete(DeleteBehavior.Restrict) ;

            builder.HasMany(d => d.UsersFriends)
                .WithOne(d => d.User)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}