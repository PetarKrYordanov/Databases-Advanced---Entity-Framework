namespace P03_SalesDatabase.Data
{

    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;
    using P03_SalesDatabase;
    public class SalesContext : DbContext
    {
        public SalesContext()
        {

        }
        public SalesContext(DbContextOptions options)
            : base(options)
        {

        }


        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);
                entity.Property(e => e.Name).HasMaxLength(50).IsUnicode(true);

                entity.Property(e => e.Quantity);

                entity.HasMany(e => e.Sales)
                         .WithOne(p => p.Product)
                         .HasForeignKey(p => p.ProductId);

                entity.Property(e => e.Description).IsRequired().HasMaxLength(250).HasDefaultValue("No description");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.Name)
                         .HasMaxLength(100)
                         .IsUnicode(true);

                entity.Property(e => e.Email)
                        .HasMaxLength(80)
                        .IsUnicode(false);

                entity.HasMany(e => e.Sales)
                        .WithOne(d => d.Customer)
                        .HasForeignKey(d => d.CustomerId);

            });

            modelBuilder.Entity<Store>(entity =>
            {

                entity.Property(e => e.Name)
                         .HasMaxLength(80)
                         .IsUnicode(true);
                entity.HasMany(e => e.Sales).WithOne(d => d.Store).HasForeignKey(d => d.StoreId);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.SaleId);

                entity.Property(e => e.Date).HasDefaultValueSql("GETDATE()");
            });
        }
    }

}
