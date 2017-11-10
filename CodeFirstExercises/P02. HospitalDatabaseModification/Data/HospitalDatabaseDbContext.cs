using Microsoft.EntityFrameworkCore;

using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalDatabaseDbContext : DbContext
    {
        public HospitalDatabaseDbContext()
        {

        }

        public HospitalDatabaseDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Patient>(ep =>
            {
                ep.Property(p => p.FirstName).HasColumnType("nvarchar(50)");
                ep.Property(p => p.LastName).HasColumnType("nvarchar(50)");
                ep.Property(p => p.Address).HasColumnType("nvarchar(250)");
                ep.Property(p => p.Email).HasColumnType("varchar(80)");
            });

            builder.Entity<Patient>()
                .HasMany(p => p.Visitations)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.PatientId);

            builder.Entity<Patient>()
                .HasMany(p => p.Diagnoses)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.PatientId);

            builder.Entity<Visitation>().Property(v => v.Comments).HasColumnType("nvarchar(250)");

            builder.Entity<Diagnose>(ed =>
            {
                ed.Property(d => d.Name).HasColumnType("nvarchar(50)");
                ed.Property(d => d.Comments).HasColumnType("nvarchar(250)");
            });

            builder.Entity<Medicament>().ToTable("Medicaments").Property(m => m.Name).HasColumnType("nvarchar(50)");

            builder.Entity<PatientMedicament>()
                .ToTable("PatientsMedicaments")
                .HasKey(pm => new { pm.PatientId, pm.MedicamentId });

            builder.Entity<Doctor>(ed =>
            {
                ed.Property(d => d.Name).HasColumnType("nvarchar(100)");
                ed.Property(d => d.Specialty).HasColumnType("nvarchar(100)");
            });

            builder.Entity<Doctor>()
                .HasMany(d => d.Visitations)
                .WithOne(d => d.Doctor)
                .HasForeignKey(d => d.DoctorId);

        }
    }
}
