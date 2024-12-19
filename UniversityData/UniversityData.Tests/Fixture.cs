using UniversityData.Domain;

namespace UniversityData.Tests;

public class UnitFixture
{
    public List<UniversityProperty> UniversityProperties =>
    [
        new() { NameUniversityProperty = "муниципальная" },
        new() { NameUniversityProperty = "частная" }
    ];

    public List<ConstructionProperty> ConstructionProperties => 
    [
        new() { NameConstructionProperty = "муниципальная" },
        new() { NameConstructionProperty = "частная" },
        new() { NameConstructionProperty = "федеральная" }
    ];

    public List<Specialty> Specialties =>
    [
        new() { Name = "Прикладная информатика", Code = "09.03.03" },
        new() { Name = "Информационные системы и технологии", Code = "09.03.02" },
        new() { Name = "Информатика и вычислительная техника", Code = "09.03.01" },
        new() { Name = "Прикладная математика и информатика", Code = "01.03.02" },
        new() { Name = "Информационная безопасность автоматизированных систем", Code = "10.05.03" }
    ];

    public List<Department> Departments => 
    [
        new() { Name = "ГИиБ", SupervisorNumber = "890918734" },
        new() { Name = "Кафедры алгебры и геометрии", SupervisorNumber = "890918735" },
        new() { Name = "Кафедра высшей математики", SupervisorNumber = "890918736" },
        new() { Name = "Кафедра информационных технологий", SupervisorNumber = "890918737" }
    ];

    public List<Rector> Rectors => 
    [
        new()
        {
            Name = "Владимир",
            Surname = "Богатырев",
            Patronymic = "Дмитриевич",
            Degree = "Доктор экономических наук",
            Title = "Профессор",
            Position = "Ректор"
        },
        new()
        {
            Name = "Дмитрий",
            Surname = "Быков",
            Patronymic = "Евгеньевич",
            Degree = "Доктор технических наук",
            Title = "Профессор",
            Position = "Ректор"
        },
        new()
        {
            Name = "Вадим",
            Surname = "Ружников",
            Patronymic = "Александрович",
            Degree = "Кандидат технических наук",
            Title = "Доцент",
            Position = "Ректор"
        }
    ];

    public List<Faculty> Faculties => 
    [
        new()
        {
            Name = "Институт информатики и кибернетики",
            WorkersCount = 16,
            StudentsCount = 110
        },
        new()
        {
            Name = "Институт экономики и управления",
            WorkersCount = 22,
            StudentsCount = 81
        },
        new()
        {
            Name = "Юридический институт",
            WorkersCount = 11,
            StudentsCount = 65
        },
        new()
        {
            Name = "Социально-гуманитарный институт",
            WorkersCount = 30,
            StudentsCount = 200
        },
        new()
        {
            Name = "Институт доп. образования",
            WorkersCount = 22,
            StudentsCount = 62
        },
        new()
        {
            Name = "Институт двигателей и энергетических установок",
            WorkersCount = 16,
            StudentsCount = 70
        }
    ];

    public List<SpecialtyTableNode> SpecialtyTableNodes =>
    [
        new() { Specialty = Specialties[0], CountGroups = 8 },
        new() { Specialty = Specialties[0], CountGroups = 17 },
        new() { Specialty = Specialties[1], CountGroups = 6 },
        new() { Specialty = Specialties[1], CountGroups = 6 },
        new() { Specialty = Specialties[2], CountGroups = 9 },
        new() { Specialty = Specialties[2], CountGroups = 4 },
        new() { Specialty = Specialties[3], CountGroups = 8 },
        new() { Specialty = Specialties[3], CountGroups = 8 },
        new() { Specialty = Specialties[4], CountGroups = 10 },
        new() { Specialty = Specialties[4], CountGroups = 8 },
        new() { Specialty = Specialties[4], CountGroups = 8 }
    ];

    public List<University> Universities =>
    [
        new()
        {
            Number = "12345",
            Name = "Самарский университет",
            Address = "Самара",
            RectorData = Rectors[0],
            UniversityProperty = UniversityProperties[0],
            ConstructionProperty = ConstructionProperties[0],
            FacultiesData = new List<Faculty> { Faculties[0], Faculties[1], Faculties[2] },
            DepartmentsData = new List<Department> { Departments[0], Departments[1] },
            SpecialtyTable = new List<SpecialtyTableNode>
            {
                SpecialtyTableNodes[0],
                SpecialtyTableNodes[1],
                SpecialtyTableNodes[2]
            }
        },
        new()
        {
            Number = "56789",
            Name = "СамГТУ",
            Address = "Самара",
            RectorData = Rectors[1],
            UniversityProperty = UniversityProperties[0],
            ConstructionProperty = ConstructionProperties[0],
            FacultiesData = new List<Faculty> { Faculties[3], Faculties[4] },
            DepartmentsData = new List<Department> { Departments[2] },
            SpecialtyTable = new List<SpecialtyTableNode>
            {
                SpecialtyTableNodes[3],
                SpecialtyTableNodes[4],
                SpecialtyTableNodes[5],
                SpecialtyTableNodes[6]
            }
        },
        new()
        {
            Number = "45678",
            Name = "ПГУТИ",
            Address = "Самара",
            RectorData = Rectors[2],
            UniversityProperty = UniversityProperties[0],
            ConstructionProperty = ConstructionProperties[2],
            FacultiesData = new List<Faculty> { Faculties[5] },
            DepartmentsData = new List<Department> { Departments[3] },
            SpecialtyTable = new List<SpecialtyTableNode>
            {
                SpecialtyTableNodes[7],
                SpecialtyTableNodes[8],
                SpecialtyTableNodes[9],
                SpecialtyTableNodes[10]
            }
        }
    ];
}