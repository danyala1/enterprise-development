using Microsoft.EntityFrameworkCore;
using UniversityData.Domain;

namespace UniversityData.Api;

/// <summary>
/// Контекст базы данных для управления сущностями университета.
/// </summary>
public class UniversityDbContext : DbContext
{
    /// <summary>
    /// Получает или задает набор университетов.
    /// </summary>
    public DbSet<University> Universities { get; set; }

    /// <summary>
    /// Получает или задает набор ректоров.
    /// </summary>
    public DbSet<Rector> Rectors { get; set; }

    /// <summary>
    /// Получает или задает набор факультетов.
    /// </summary>
    public DbSet<Faculty> Faculties { get; set; }

    /// <summary>
    /// Получает или задает набор департаментов.
    /// </summary>
    public DbSet<Department> Departments { get; set; }

    /// <summary>
    /// Получает или задает набор специальностей.
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
            .HasOne(u => u.Rector)
            .WithMany(r => r.University)
            .HasForeignKey(u => u.RegistrationNumber);

        modelBuilder.Entity<University>()
            .HasMany(u => u.Faculties)
            .WithOne()
            .HasForeignKey(f => f.Id); 

        modelBuilder.Entity<Faculty>()
            .HasMany(f => f.Departments)
            .WithOne()
            .HasForeignKey(d => d.Id); 

        modelBuilder.Entity<Department>()
            .HasMany(d => d.Specialties)
            .WithOne()
            .HasForeignKey(s => s.Id); 

    }
}