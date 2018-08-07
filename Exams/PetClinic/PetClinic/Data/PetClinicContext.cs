namespace PetClinic.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetClinic.Models;

    public class PetClinicContext : DbContext
    {
        public PetClinicContext() { }

        public PetClinicContext(DbContextOptions options)
            :base(options) { }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<ProcedureAnimalAid> ProceduresAnimalAids { get; set; }
        public DbSet<AnimalAid> AnimalAids { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<Animal>(new AnimalConfiguration());
            builder.ApplyConfiguration<Passport>(new PassportConfiguration());
            builder.ApplyConfiguration<Vet>(new VetConfiguration());
            builder.ApplyConfiguration<ProcedureAnimalAid>(new ProcedureAnimalAidsConfiguration());
            builder.ApplyConfiguration<AnimalAid>(new AnimalAidConfiguration());
        }
    }
}
