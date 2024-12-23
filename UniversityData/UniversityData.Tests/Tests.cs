using UniversityData.Domain;
using Xunit;

namespace UnitTests;

/// <summary>
/// Класс для тестирования функциональности университетов.
/// </summary>
public class Tests
{
    private readonly List<University> _universities;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="Tests"/> и загружает список университетов.
    /// </summary>
    public Tests() => _universities = Fixture.GetUniversities();

    /// <summary>
    /// Получение университета по имени.
    /// </summary>
    [Fact]
    public void GetUniversityByName()
    {
        var universityName = "Tech University";
        var result = _universities.FirstOrDefault(u => u.Name == universityName);

        Assert.NotNull(result);
        Assert.Equal(universityName, result.Name);
    }

    /// <summary>
    /// Получение факультетов с департаментами и специальностями.
    /// </summary>
    [Fact]
    public void GetFacultiesWithDepartmentsAndSpecialties()
    {
        var universityName = "Tech University";
        var university = _universities.FirstOrDefault(u => u.Name == universityName);

        Assert.NotNull(university);
        Assert.Single(university.Faculties);
        Assert.Equal(2, university.Faculties[0].Departments.Count);
    }

    /// <summary>
    /// Получение топ-5 популярных специальностей.
    /// </summary>
    [Fact]
    public void GetTop5PopularSpecialties()
    {
        var specialties = _universities
            .SelectMany(u => u.Faculties)
            .SelectMany(f => f.Departments)
            .SelectMany(d => d.Specialties)
            .GroupBy(s => new { s.Code, s.Name })
            .Select(g => new
            {
                g.Key.Code,
                g.Key.Name,
                GroupCount = g.Sum(s => s.GroupCount)
            })
            .OrderByDescending(s => s.GroupCount)
            .Take(5)
            .ToList();

        Assert.Equal(5, specialties.Count);
    }

    /// <summary>
    /// Получение университетов с максимальным количеством департаментов.
    /// </summary>
    [Fact]
    public void GetUniversitiesWithMaxDepartments()
    {
        var result = _universities
            .OrderByDescending(u => u.Faculties.Sum(f => f.Departments.Count))
            .ThenBy(u => u.Name)
            .ToList();

        Assert.True(result.Count > 0);
    }

    /// <summary>
    /// Получение университетов по типу собственности.
    /// </summary>
    [Fact]
    public void GetUniversitiesByOwnershipType()
    {
        var ownership = "Municipal";
        var result = _universities
            .Where(u => u.InstitutionOwnership == ownership)
            .Select(u => new
            {
                u.Name,
                GroupCount = u.Faculties
                    .SelectMany(f => f.Departments)
                    .SelectMany(d => d.Specialties)
                    .Sum(s => s.GroupCount)
            })
            .ToList();

        Assert.Equal(2, result.Count);
    }

    /// <summary>
    /// Получение университетов по типам собственности.
    /// </summary>
    [Fact]
    public void GetUniversitiesByOwnershipTypes()
    {
        var result = _universities
            .GroupBy(u => new { u.InstitutionOwnership, u.BuildingOwnership })
            .Select(g => new
            {
                Ownership = g.Key,
                FacultiesCount = g.Sum(u => u.Faculties.Count),
                DepartmentsCount = g.Sum(u => u.Faculties.Sum(f => f.Departments.Count)),
                SpecialtiesCount = g.Sum(u => u.Faculties
                    .SelectMany(f => f.Departments)
                    .SelectMany(d => d.Specialties)
                    .Count())
            })
            .ToList();

        Assert.NotEmpty(result);
    }
}
