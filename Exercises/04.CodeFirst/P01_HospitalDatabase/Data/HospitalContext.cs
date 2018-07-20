namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;
    using P01_HospitalDatabase;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }
        public HospitalContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientMedicament> PatientMedicament { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
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

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(m => m.MedicamentId);

                entity.Property(m => m.Name).HasMaxLength(50)
                .IsUnicode(true);

                entity.HasMany(d => d.Prescriptions)
                .WithOne(e => e.Medicament)
                .HasForeignKey(e => e.MedicamentId);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(p => p.PatientId);

                entity.Property(p => p.FirstName).IsUnicode(true).HasMaxLength(50);

                entity.Property(p => p.LastName).HasMaxLength(50).IsUnicode(true);

                entity.Property(p => p.Address).HasMaxLength(250).IsUnicode(true);

                entity.Property(p => p.Email).HasMaxLength(80).IsUnicode(false);

                entity.HasMany(d => d.Prescriptions)
                .WithOne(e => e.Patient)
                .HasForeignKey(e => e.PatientId);

                entity.HasMany(d => d.Diagnoses)
                    .WithOne(e => e.Patient)
                    .HasForeignKey(e => e.PatientId);

                entity.HasMany(v => v.Visitations)
                        .WithOne(e => e.Patient)
                        .HasForeignKey(e => e.PatientId);
            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.Property(v => v.Comments).IsUnicode(true).HasMaxLength(250);

                entity.HasOne(d => d.Doctor)
                       .WithMany(e => e.Visitations)
                       .HasForeignKey(d => d.DoctorId);
            });

            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.Property(d => d.Name).HasMaxLength(50).IsUnicode(true);

                entity.Property(d => d.Comments).HasMaxLength(250).IsUnicode(true);

                entity.HasOne(p => p.Patient)
                    .WithMany(d => d.Diagnoses)
                    .HasForeignKey(d=>d.DiagnoseId);
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.Property(m => m.Name).HasMaxLength(50).IsUnicode(true);
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {

                entity.HasKey(pm => new
                {
                    pm.PatientId,
                    pm.MedicamentId
                });
            });
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(d => d.DoctorId);


                entity.Property(d => d.Name).HasMaxLength(100).IsUnicode(true);

                entity.Property(d => d.Specialty).HasMaxLength(100).IsUnicode(true);
            });
        }
    }
}
