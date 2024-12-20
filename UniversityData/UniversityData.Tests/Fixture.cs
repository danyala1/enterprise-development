using UniversityData.Domain;

namespace UnitTests;

public static class Fixture
{
    public static List<University> GetUniversities() =>
    [
        
            new University
            {
                RegistrationNumber = 1,
                Name = "Tech University",
                Address = "123 Main St",
                Rector = new Rector
                {
                    FullName = "John Doe",
                    Degree = "PhD",
                    Title = "Professor",
                    Position = "Rector"
                },
                InstitutionOwnership = "Municipal",
                BuildingOwnership = "Federal",
                Faculties = new List<Faculty>
                {
                    new Faculty
                    {
                        Name = "Engineering",
                        Departments = new List<Department>
                        {
                            new Department
                            {
                                Name = "Computer Science",
                                Specialties = new List<Specialty>
                                {
                                    new Specialty { Code = "CS101", Name = "Software Engineering", GroupCount = 10 },
                                    new Specialty { Code = "CS102", Name = "Data Science", GroupCount = 5 }
                                }
                            },
                            new Department
                            {
                                Name = "Mechanical Engineering",
                                Specialties = new List<Specialty>
                                {
                                    new Specialty { Code = "ME101", Name = "Robotics", GroupCount = 7 }
                                }
                            }
                        }
                    }
                }
            }
        ];
    }