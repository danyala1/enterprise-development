namespace UniversityData.Tests;
using System.Linq;

public class UnitTests(UnitFixture unitFixture) : IClassFixture<UnitFixture>
{
    private readonly UnitFixture _fixture = unitFixture;
    /// <summary>
    /// Запрос 1 - Вывести информацию о выбранном вузе.
    /// </summary>
    [Fact]
    public void InformationOfUniversity()
    {
        string universityNumber = "12345";
        var result = (from university in _fixture.Universities
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
        var result = (from university in _fixture.Universities
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
        var expectedSpecialties = new List<string> { "10.05.03", "09.03.03", "09.03.02", "09.03.01", "01.03.02" };

        var result = (from specialtyNode in _fixture.SpecialtyTableNodes
                      let specialtyCode = specialtyNode.Specialty?.Code
                      where specialtyCode != null
                      group specialtyNode by specialtyCode into specialtyGroup
                      orderby specialtyGroup.Count() descending
                      select specialtyGroup.Key).Take(5).ToList();
        Assert.Equal(expectedSpecialties.Count, result.Count);

        for (var i = 0; i < expectedSpecialties.Count; i++)
        {
            Assert.Equal(expectedSpecialties[i], result[i]);
        }

    }
    /// <summary>
    /// Запрос 4 - Вывести информацию о ВУЗах с максимальным количеством кафедр, упорядочить по названию.
    /// </summary>
    [Fact]
    public void MaxCountDepartments()
    {
        var result = (from university in _fixture.Universities
                      where university.DepartmentsData.Count == _fixture.Universities.Max(x => x.DepartmentsData.Count)
                      select university).ToList();
        Assert.Single(result);
    }
    /// <summary>
    /// Запрос 5 - Вывести информацию о ВУЗах с заданной собственностью учреждения, и количество групп в ВУЗе.
    /// </summary>
    [Fact]
    public void UniversityWithProperty()
    {
        string universityType = "муниципальная";
        int requiredCountGroups = 27;

        var result = (from university in _fixture.Universities
                      where university.UniversityProperty == universityType
                      where university.SpecialtyTable.Sum(x => x.CountGroups) == requiredCountGroups
                      select university).ToList();
        Assert.Equal(1, result.Count);
    }
    /// <summary>
    /// Запрос 6 - Вывести информацию о количестве факультетов, кафедр, специальностей по каждому типу собственности учреждения и собственности здания.
    /// </summary>
    [Fact]
    public void CountDepartments()
    {
        var result = (from university in _fixture.Universities
                      group university by university.ConstructionProperty into universityConstGroup
                      select new
                      {
                          ConstProp = universityConstGroup.Key,
                          UniversityProperties = (from university in universityConstGroup
                                                  group university by university.UniversityProperty into universityPropGroup
                                                  select new
                                                  {
                                                      UniversityProp = universityPropGroup.Key,
                                                      Faculties = universityConstGroup.Sum(x => x.FacultiesData.Count),
                                                      Departments = universityConstGroup.Sum(x => x.DepartmentsData.Count),
                                                      Specialities = universityConstGroup.Sum(x => x.SpecialtyTable.Count)
                                                  }).ToList()
                      }).ToList();

        // Проверка результатов
        Assert.Equal("муниципальная", result[0].UniversityProperties[0].UniversityProp);
        Assert.Equal("муниципальная", result[1].UniversityProperties[0].UniversityProp);
        Assert.Equal("муниципальная", result[0].ConstProp);
        Assert.Equal("федеральная", result[1].ConstProp);
        Assert.Equal(5, result[0].UniversityProperties[0].Faculties);
        Assert.Equal(1, result[1].UniversityProperties[0].Faculties);
        Assert.Equal(3, result[0].UniversityProperties[0].Departments);
        Assert.Equal(1, result[1].UniversityProperties[0].Departments);
        Assert.Equal(7, result[0].UniversityProperties[0].Specialities);
        Assert.Equal(4, result[1].UniversityProperties[0].Specialities);

    }
}