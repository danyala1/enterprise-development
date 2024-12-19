namespace UniversityData.Tests;

public class UnitTests(UnitFixture unitFixture) : IClassFixture<UnitFixture>
{
    /// <summary>
    /// Запрос 1 - Вывести информацию о выбранном вузе.
    /// </summary>
    [Fact]
    public void InformationOfUniversity()
    {
        string universityNumber = "12345";
        var result = (from university in unitFixture.Universities
                      where university.Number == universityNumber
                      select university).ToList();
        Assert.Equal("Самарский университет", result[0].Name);
    }
    /// <summary>
    /// Запрос 2 - Вывести информацию о факультетах, кафедрах и специальностях данного вуза.
    /// </summary>
    [Fact]
    public void InformationOfStructure()
    {
        string universityNumber = "45678";
        var result = (from university in unitFixture.Universities
                      where university.Number == universityNumber
                      select university).ToList();
        Assert.Single(result[0].FacultiesData);
        Assert.Single(result[0].DepartmentsData);
        Assert.Equal(4, result[0].SpecialtyTable.Count);
    }
    /// <summary>
    /// Запрос 3 - Вывести информацию о топ 5 популярных специальностях (с максимальным количеством групп).
    /// </summary>
    [Fact]
    public void TopFiveSpecialties()
    {
        var expectedSpecialties = new List<string> { "10.05.03", "09.03.03", "01.03.02", "09.03.01", "09.03.02" };

        var result = (from specialtyNode in unitFixture.SpecialtyTableNodes
                      let specialtyCode = specialtyNode.Specialty?.Code
                      where specialtyCode != null
                      group specialtyNode by specialtyCode into specialtyGroup
                      orderby specialtyGroup.Sum(x => x.CountGroups) descending
                      select new
                      {
                          SpecialtyCode = specialtyGroup.Key,
                          TotalCountGroups = specialtyGroup.Sum(x => x.CountGroups)
                      }).Take(5).Select(x => x.SpecialtyCode).ToList();

        Assert.Equal(expectedSpecialties.Count, result.Count);
        Assert.Equal(expectedSpecialties, result);
    }
    /// <summary>
    /// Запрос 4 - Вывести информацию о ВУЗах с максимальным количеством кафедр, упорядочить по названию.
    /// </summary>
    [Fact]
    public void MaxCountDepartments()
    {
        var result = (from university in unitFixture.Universities
                      where university.DepartmentsData.Count == unitFixture.Universities.Max(x => x.DepartmentsData.Count)
                      select university).ToList();
        Assert.Single(result);
    }
    /// <summary>
    /// Запрос 5 - Вывести информацию о ВУЗах с заданной собственностью учреждения, и количество групп в ВУЗе.
    /// </summary>
    [Fact]
    public void UniversityWithProperty()
    {
        var result = unitFixture.Universities
            .Where(university => university.UniversityProperty != null &&
                                 university.UniversityProperty.NameUniversityProperty == "муниципальная")
            .Select(university => new
            {
                university.Id,
                university.Name,
                university.Number,
                university.RectorId,
                university.ConstructionProperty,
                university.UniversityProperty,
                count = university.SpecialtyTable.Sum(specialtyNode => specialtyNode.CountGroups)
            })
            .ToList();

        Assert.Equal(3, result.Count);
    }
    /// <summary>
    /// Запрос 6 - Вывести информацию о количестве факультетов, кафедр, специальностей по каждому типу собственности учреждения и собственности здания.
    /// </summary>
    [Fact]
    public void CountDepartments()
    {
        var result = (from university in unitFixture.Universities
                      group university by new
                      {
                          university.ConstructionProperty,
                          university.UniversityProperty
                      } into groupedUniversities
                      select new
                      {
                          ConstProp = groupedUniversities.Key.ConstructionProperty,
                          UniversityProp = groupedUniversities.Key.UniversityProperty,
                          Faculties = groupedUniversities.Sum(x => x.FacultiesData.Count),
                          Departments = groupedUniversities.Sum(x => x.DepartmentsData.Count),
                          Specialities = groupedUniversities.Sum(x => x.SpecialtyTable.Count)
                      }).ToList();

        Assert.Equal("муниципальная", result[0].UniversityProp.NameUniversityProperty);
        Assert.Equal("муниципальная", result[1].UniversityProp.NameUniversityProperty); 
        Assert.Equal("муниципальная", result[0].ConstProp.NameConstructionProperty);
        Assert.Equal("муниципальная", result[1].ConstProp.NameConstructionProperty);
        Assert.Equal(3, result[0].Faculties);
        Assert.Equal(2, result[1].Faculties);
        Assert.Equal(2, result[0].Departments);
        Assert.Equal(1, result[1].Departments);
        Assert.Equal(3, result[0].Specialities);
        Assert.Equal(4, result[1].Specialities);
    }
}