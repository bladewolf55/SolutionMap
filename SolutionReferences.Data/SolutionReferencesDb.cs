using Microsoft.EntityFrameworkCore;
using SolutionReferences.Data.Models;


namespace SolutionReferences.Data
{
    public class SolutionReferencesDb : DbContext
    {
        private readonly string _connectionString;
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Reference> References { get; set; }

        public SolutionReferencesDb(): this(connectionString: null) { }

        public SolutionReferencesDb(string connectionString)
        {
            // HACK: Find a way to consistently point to the same db
            var dbPath = @"G:\My Drive\Clients\_SM\Solution References\src\SolutionReferences.Data\solutionReferences.db";

            _connectionString = connectionString ?? $"Data Source={dbPath}";
        }

        public SolutionReferencesDb(DbContextOptions<SolutionReferencesDb> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Solution>()
                .ToTable("Solutions")
                .HasMany(a => a.Projects);

            modelBuilder.Entity<Project>()
                .ToTable("Projects")
                .HasMany(a => a.Solutions);

            modelBuilder.Entity<Project>()                
                .HasMany(a => a.References)
                .WithMany(a => a.Projects);

            modelBuilder.Entity<Reference>()
                .ToTable("References")
                .HasOne(a => a.ReferencedByProject);                

            base.OnModelCreating(modelBuilder);
        }
    }
}
