using EFMigrations.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFMigrations.Context;

internal class UniversityContext : DbContext
{
    public DbSet<Student> Students { get; init; } = default!;
    public DbSet<Course> Courses { get; init; } = default!;
    public DbSet<Grade> Grades { get; init; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDb;Database=University;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Phone).IsRequired();
            entity.Property(e => e.Address).IsRequired();
            entity.Property(e => e.DateOfBirth).IsRequired();
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Duration).IsRequired();
            entity.Property(e => e.Fee).IsRequired();
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.StudentId).IsRequired();
            entity.Property(e => e.CourseId).IsRequired();
            entity.Property(e => e.Mark).IsRequired();

            entity.HasOne<Student>()
                .WithMany()
                .HasForeignKey(e => e.StudentId);

            entity.HasOne<Course>()
                .WithMany()
                .HasForeignKey(e => e.CourseId);
        });
    }
}
