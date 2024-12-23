using UniversityData.Domain;

namespace UnitTests;

public static class Fixture
{
    public static List<University> GetUniversities() =>
        new List<University>
        {
            new University
            {
                RegistrationNumber = 1,
                Name = "Tech University",
                Address = "123 Main St",
                InstitutionOwnership = "Municipal",
                BuildingOwnership = "Federal",
                RectorId = 1,
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
            },
            new University
            {
                RegistrationNumber = 2,
                Name = "Science University",
                Address = "456 Science Ave",
                InstitutionOwnership = "Private",
                BuildingOwnership = "Private",
                RectorId = 2,
                Faculties = new List<Faculty>
                {
                    new Faculty
                    {
                        Name = "Natural Sciences",
                        Departments = new List<Department>
                        {
                            new Department
                            {
                                Name = "Physics",
                                Specialties = new List<Specialty>
                                {
                                    new Specialty { Code = "PH101", Name = "Quantum Mechanics", GroupCount = 8 },
                                    new Specialty { Code = "PH102", Name = "Thermodynamics", GroupCount = 6 }
                                }
                            },
                            new Department
                            {
                                Name = "Chemistry",
                                Specialties = new List<Specialty>
                                {
                                    new Specialty { Code = "CH101", Name = "Organic Chemistry", GroupCount = 12 },
                                    new Specialty { Code = "CH102", Name = "Inorganic Chemistry", GroupCount = 9 }
                                }
                            }
                        }
                    }
                }
            },
            new University
            {
                RegistrationNumber = 3,
                Name = "Arts University",
                Address = "789 Arts Blvd",
                InstitutionOwnership = "Municipal",
                BuildingOwnership = "State",
                RectorId = 3,
                Faculties = new List<Faculty>
                {
                    new Faculty
                    {
                        Name = "Fine Arts",
                        Departments = new List<Department>
                        {
                            new Department
                            {
                                Name = "Visual Arts",
                                Specialties = new List<Specialty>
                                {
                                    new Specialty { Code = "VA101", Name = "Painting", GroupCount = 15 },
                                    new Specialty { Code = "VA102", Name = "Sculpture", GroupCount = 10 }
                                }
                            },
                            new Department
                            {
                                Name = "Performing Arts",
                                Specialties = new List<Specialty>
                                {
                                    new Specialty { Code = "PA101", Name = "Theater Arts", GroupCount = 5 },
                                    new Specialty { Code = "PA102", Name = "Music Performance", GroupCount = 7 }
                                }
                            }
                        }
                    }
                }
            },
        };
}