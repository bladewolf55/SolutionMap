using Microsoft.EntityFrameworkCore;
using SolutionReferences.Data.Models;
using System;
using System.IO;
using System.Reflection;


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
            //string workingDirectory = Environment.CurrentDirectory;
            //string solutionDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            //string projectDirectory = Path.Combine(solutionDirectory, Assembly.GetExecutingAssembly().GetName().Name);  
            //var dbPath = Path.Combine(projectDirectory,"solutionReferences.db");
            //_connectionString = connectionString ?? $"Data Source={dbPath}";
        }

        public SolutionReferencesDb(DbContextOptions<SolutionReferencesDb> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite(_connectionString);
            optionsBuilder.UseSqlite();
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
