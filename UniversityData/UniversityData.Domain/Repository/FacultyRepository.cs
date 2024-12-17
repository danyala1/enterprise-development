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
        for (var i = 0; i < 6; ++i)
        {
            _faculties.Add(new Faculty { Id = i });
        }

        _faculties[0].Name = "Институт информатики и кибернетики";
        _faculties[0].WorkersCount = 16;
        _faculties[0].StudentsCount = 110;
        _faculties[0].UniversityId = 0;

        _faculties[1].Name = "Институт экономики и управления";
        _faculties[1].WorkersCount = 22;
        _faculties[1].StudentsCount = 81;
        _faculties[1].UniversityId = 0;

        _faculties[2].Name = "Юридический институт";
        _faculties[2].WorkersCount = 11;
        _faculties[2].StudentsCount = 65;
        _faculties[2].UniversityId = 0;

        _faculties[3].Name = "Социально-гуманитарный институт";
        _faculties[3].WorkersCount = 30;
        _faculties[3].StudentsCount = 200;
        _faculties[3].UniversityId = 1;

        _faculties[4].Name = "Институт доп. образования";
        _faculties[4].WorkersCount = 22;
        _faculties[4].StudentsCount = 62;
        _faculties[4].UniversityId = 1;

        _faculties[5].Name = "Институт двигателей и энергетических установок";
        _faculties[5].WorkersCount = 16;
        _faculties[5].StudentsCount = 70;
        _faculties[5].UniversityId = 2;
    }

    public void Add(Faculty faculty)
    {
        if (faculty == null) throw new ArgumentNullException(nameof(faculty));

        faculty.Id = _faculties.Count; // Присвоение нового ID
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