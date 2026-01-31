using Microsoft.EntityFrameworkCore;
using SolutionMap.Domain.Models;

namespace SolutionMap.Database;

public class SolutionMapDb : DbContext
{
    private readonly string? _connectionString;
    public DbSet<Solution> Solutions => Set<Solution>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Reference> References => Set<Reference>();

    public SolutionMapDb() : this(connectionString: "") { }

    public SolutionMapDb(string connectionString)
    {
        _connectionString = connectionString;
    }

    public SolutionMapDb(DbContextOptions<SolutionMapDb> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies().UseSqlite(_connectionString);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Solution>()
            .HasMany(s => s.Projects)
            .WithMany(p => p.Solutions)
            .UsingEntity(j => j.ToTable("SolutionProject")
            );

        modelBuilder.Entity<Project>()
            .HasMany(p => p.ProjectReferences)
            .WithMany(r => r.Projects)
            .UsingEntity(j => j.ToTable("ProjectReference"))
            .Ignore(a => a.ProjectReferences)
            .Ignore(a => a.PackageReferences)
            .Ignore(a => a.SystemReferences)
        ;

        base.OnModelCreating(modelBuilder);
    }
}
