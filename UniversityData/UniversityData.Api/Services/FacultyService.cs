using UniversityData.Domain;
using System.Xml.Linq;

namespace Api
{
    public class FacultyService : IFacultyService
    {
        private readonly List<Faculty> _faculties = new();

        public List<Faculty> GetAll()
        {
            return _faculties;
        }

        public Faculty? GetById(int id)
        {
            return _faculties.FirstOrDefault(f => f.Id == id);
        }

        public void Create(Faculty faculty)
        {
            _faculties.Add(faculty);
        }

        public void Update(int id, Faculty faculty)
        {
            var existingFaculty = GetById(id);
            if (existingFaculty != null)
            {
                existingFaculty.Name = faculty.Name;
                existingFaculty.Departments = faculty.Departments;
            }
        }

        public void Delete(int id)
        {
            var faculty = GetById(id);
            if (faculty != null)
            {
                _faculties.Remove(faculty);
            }
        }
    }
}
