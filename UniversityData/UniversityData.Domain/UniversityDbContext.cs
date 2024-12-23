using Microsoft.EntityFrameworkCore;
using UniversityData.Domain;

namespace UniversityData.Api;

/// <summary>
/// Контекст базы данных для управления сущностями университета.
/// </summary>
public class UniversityDbContext : DbContext
{
    /// <summary>
    /// Набор университетов.
    /// </summary>
    public DbSet<University> Universities { get; set; }

    /// <summary>
    /// Набор ректоров.
    /// </summary>
    public DbSet<Rector> Rectors { get; set; }

    /// <summary>
    /// Набор факультетов.
    /// </summary>
    public DbSet<Faculty> Faculties { get; set; }

    /// <summary>
    /// Набор департаментов.
    /// </summary>
    public DbSet<Department> Departments { get; set; }

    /// <summary>
    /// Набор специальностей.
    /// </summary>
    public DbSet<Specialty> Specialties { get; set; }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="UniversityDbContext"/>.
    /// </summary>
    /// <param name="options">Параметры контекста базы данных.</param>
    public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
        : base(options)
    { }

    /// <summary>
    /// Конфигурирует модель при создании контекста.
    /// </summary>
    /// <param name="modelBuilder">Объект для построения модели.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<University>()
            .HasOne<Rector>()
            .WithMany(r => r.Universities)
            .HasForeignKey(u => u.RectorId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<University>()
            .HasMany(u => u.Faculties)
            .WithOne()
            .HasForeignKey(f => f.Id);

        modelBuilder.Entity<Faculty>()
            .HasMany(f => f.Departments)
            .WithOne()
            .HasForeignKey(d => d.Id);

        modelBuilder.Entity<Department>()
            .HasMany(d => d.DepartmentSpecialties)
            .WithOne(ds => ds.Department)
            .HasForeignKey(ds => ds.DepartmentId);

        modelBuilder.Entity<Specialty>()
            .HasMany(s => s.DepartmentSpecialties)
            .WithOne(ds => ds.Specialty)
            .HasForeignKey(ds => ds.SpecialtyId);

        modelBuilder.Entity<Specialty>()
            .Property(s => s.Code)
            .IsRequired();

        modelBuilder.Entity<Specialty>()
            .Property(s => s.Name)
            .IsRequired();
    }
}
