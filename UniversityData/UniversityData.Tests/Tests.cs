using UniversityData.Domain;

namespace UnitTests;

public class Tests
{
    private readonly List<University> _universities;

    public Tests()
    {
        _universities = Fixture.GetUniversities();
    }

    [Fact]
    public void Query_University_ByName()
    {
        var universityName = "Tech University";
        var result = _universities.FirstOrDefault(u => u.Name == universityName);

        Assert.NotNull(result);
        Assert.Equal(universityName, result.Name);
    }

    [Fact]
    public void Query_Faculties_Departments_Specialties()
    {
        var universityName = "Tech University";
        var university = _universities.FirstOrDefault(u => u.Name == universityName);

        Assert.NotNull(university);
        Assert.Single(university.Faculties);
        Assert.Equal(2, university.Faculties[0].Departments.Count);
    }

    [Fact]
    public void Query_Top5_Popular_Specialties()
    {
        var specialties = _universities
            .SelectMany(u => u.Faculties)
            .SelectMany(f => f.Departments)
            .SelectMany(d => d.Specialties)
            .OrderByDescending(s => s.GroupCount)
            .Take(5)
            .ToList();

        Assert.Equal(3, specialties.Count);
    }

    [Fact]
    public void Query_Universities_With_Max_Departments()
    {
        var result = _universities
            .OrderByDescending(u => u.Faculties.Sum(f => f.Departments.Count))
            .ThenBy(u => u.Name)
            .ToList();

        Assert.Single(result);
    }

    [Fact]
    public void Query_Universities_By_Ownership()
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

        Assert.Single(result);
    }

    [Fact]
    public void Query_Count_By_Ownership_Types()
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