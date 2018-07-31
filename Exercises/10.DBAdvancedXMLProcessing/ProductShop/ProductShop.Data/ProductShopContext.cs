namespace ProductShop.Data
{
    using Microsoft.EntityFrameworkCore;

    using ProductShop.Models;
    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
        {

        }
        public ProductShopContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<Product>(new ProductConfiguration());
            builder.ApplyConfiguration<Category>(new CategoryConfiguration());
            builder.ApplyConfiguration<CategoryProduct>(new CategoryProductConfiguration());
            builder.ApplyConfiguration<UserFriend>(new UserFriendConfiguration());
            builder.ApplyConfiguration<User>(new UsersConfiguration());
        }
    }
}
