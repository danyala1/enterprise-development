namespace UniversityData.Tests;
using System.Collections.Generic;
using UniversityData.Domain;

public class UnitFixture
{
    public List<Specialty> Specialties =>
    [
        new() { Code = "09.03.03", Name = "Прикладная информатика" },
        new() { Code = "09.03.02", Name = "Информационные системы и технологии" },
        new() { Code = "09.03.01", Name = "Информатика и вычислительная техника" },
        new() { Code = "01.03.02", Name = "Прикладная математика и информатика" },
        new() { Code = "10.05.03", Name = "Информационная безопасность автоматизированных систем" }
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
        new() { Name = "Институт информатики и кибернетики", WorkersCount = 16, StudentsCount = 110 },
        new() { Name = "Институт экономики и управления", WorkersCount = 22, StudentsCount = 81 },
        new() { Name = "Юридический институт", WorkersCount = 11, StudentsCount = 65 },
        new() { Name = "Социально-гумманитарный институт", WorkersCount = 30, StudentsCount = 200 },
        new() { Name = "Институт доп. образования", WorkersCount = 22, StudentsCount = 62 },
        new() { Name = "Институт двигателей и энергетических установок", WorkersCount = 16, StudentsCount = 70 }
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
            UniversityProperty = "муниципальная", 
            ConstructionProperty = "муниципальная", 
            FacultiesData = Faculties.Take(3).ToList(), 
            DepartmentsData = Departments.Take(2).ToList(), 
            SpecialtyTable = SpecialtyTableNodes.Take(3).ToList()
        },
        new() 
        { 
            Number = "56789", 
            Name = "СамГТУ", 
            Address = "Самара", 
            RectorData = Rectors[1], 
            UniversityProperty = "муниципальная", 
            ConstructionProperty = "муниципальная", 
            FacultiesData = Faculties.Skip(3).Take(2).ToList(),
            DepartmentsData = Departments.Skip(2).Take(1).ToList(), 
            SpecialtyTable = SpecialtyTableNodes.Skip(3).Take(4).ToList()
        },
        new() 
        { 
            Number = "45678", 
            Name = "ПГУТИ", 
            Address = "Самара", 
            RectorData = Rectors[2], 
            UniversityProperty = "муниципальная", 
            ConstructionProperty = "федеральная", 
            FacultiesData = Faculties.Skip(5).Take(1).ToList(), 
            DepartmentsData = Departments.Skip(3).Take(1).ToList(), 
            SpecialtyTable = SpecialtyTableNodes.Skip(7).Take(4).ToList()
        }
    ];     
}