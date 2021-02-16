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

        public SolutionReferencesDb() { }

        public SolutionReferencesDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SolutionReferencesDb(DbContextOptions<SolutionReferencesDb> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
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

            modelBuilder.Entity<Reference>()
                .ToTable("References")
                .HasMany(a => a.ParentProjects);

            modelBuilder.Entity<Reference>()
                .ToTable("References")
                .HasOne(a => a.ProjectReference);

            base.OnModelCreating(modelBuilder);
        }
    }
}
