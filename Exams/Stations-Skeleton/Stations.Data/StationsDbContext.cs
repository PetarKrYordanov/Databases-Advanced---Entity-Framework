using Microsoft.EntityFrameworkCore;
using Stations.Models;
using Stations.Models.Enums;


namespace Stations.Data
{
	public class StationsDbContext : DbContext
	{
		public StationsDbContext()
		{
		}

		public StationsDbContext(DbContextOptions options)
			: base(options)
		{
		}
        public DbSet<TrainSeat> TrainSeats { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<SeatingClass> SeatingClasses { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<CustomerCard> Cards { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
            builder.ApplyConfiguration<Station>(new StationConfiguration());
            builder.ApplyConfiguration<SeatingClass>(new SeatingClassesConfiguration());

            builder.ApplyConfiguration<Train>(new TrainConfiguration());

            builder.ApplyConfiguration<Trip>(new TripConfiguration());
            builder.ApplyConfiguration<CustomerCard>(new CustomerCardConfiguration());
        }
	}
}