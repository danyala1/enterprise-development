using UniversityData.Domain.Repository;
using UniversityData.Domain;

public class FacultyRepository : IFacultyRepository
{
    private readonly List<Faculty> _faculties;

    public FacultyRepository()
    {
        _faculties = new List<Faculty>();
        InitializeFaculties();
    }

    private void InitializeFaculties()
    {
        _faculties.AddRange(GetInitialFaculties());
    }

    private IEnumerable<Faculty> GetInitialFaculties()
    {
        return new List<Faculty>
    {
        new Faculty
        {
            Id = 0,
            Name = "Институт информатики и кибернетики",
            WorkersCount = 16,
            StudentsCount = 110,
            UniversityId = 0
        },
        new Faculty
        {
            Id = 1,
            Name = "Институт экономики и управления",
            WorkersCount = 22,
            StudentsCount = 81,
            UniversityId = 0
        },
        new Faculty
        {
            Id = 2,
            Name = "Юридический институт",
            WorkersCount = 11,
            StudentsCount = 65,
            UniversityId = 0
        },
        new Faculty
        {
            Id = 3,
            Name = "Социально-гуманитарный институт",
            WorkersCount = 30,
            StudentsCount = 200,
            UniversityId = 1
        },
        new Faculty
        {
            Id = 4,
            Name = "Институт доп. образования",
            WorkersCount = 22,
            StudentsCount = 62,
            UniversityId = 1
        },
        new Faculty
        {
            Id = 5,
            Name = "Институт двигателей и энергетических установок",
            WorkersCount = 16,
            StudentsCount = 70,
            UniversityId = 2
        }
    };
    }

    public void Add(Faculty faculty)
    {
        if (faculty == null) throw new ArgumentNullException(nameof(faculty));

        faculty.Id = _faculties.Count;
        _faculties.Add(faculty);
    }

    public void Update(Faculty faculty)
    {
        var existingFaculty = GetById(faculty.Id);
        if (existingFaculty != null)
        {
            existingFaculty.Name = faculty.Name;
            existingFaculty.WorkersCount = faculty.WorkersCount;
            existingFaculty.StudentsCount = faculty.StudentsCount;
            existingFaculty.UniversityId = faculty.UniversityId;
        }
    }

    public void Delete(int id)
    {
        var facultyToRemove = GetById(id);
        if (facultyToRemove != null)
            _faculties.Remove(facultyToRemove);
    }

    public Faculty GetById(int id)
    {
        return _faculties.FirstOrDefault(f => f.Id == id);
    }

    public IEnumerable<Faculty> GetAll()
    {
        return new List<Faculty>(_faculties);
    }
}