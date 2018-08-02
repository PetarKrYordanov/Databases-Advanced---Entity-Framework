namespace CarDealership.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Models;
    public class CarDealershipContext : DbContext
    {
        public CarDealershipContext()
        {
           
        }
        public CarDealershipContext(DbContextOptions options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Customer>  Customers { get; set; }
        public DbSet<PartCar> PartCars { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<Supplier>(new SupplierConfiguration());
            builder.ApplyConfiguration<Part>(new PartsConfiguration());
            builder.ApplyConfiguration<PartCar>(new ParCarsConfiguration());
            builder.ApplyConfiguration<Car>(new CarsConfiguration());
            builder.ApplyConfiguration<Customer>(new CustomerConfiguration());
        }
    }
}
