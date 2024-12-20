using UniversityData.Domain;
using System.Xml.Linq;

namespace Api
{
    public class DepartmentService : IDepartmentService
    {
        private readonly List<Department> _departments = new();

        public List<Department> GetAll()
        {
            return _departments;
        }

        public Department? GetById(int id)
        {
            return _departments.FirstOrDefault(d => d.Id == id);
        }

        public void Create(Department department)
        {
            _departments.Add(department);
        }

        public void Update(int id, Department department)
        {
            var existingDepartment = GetById(id);
            if (existingDepartment != null)
            {
                existingDepartment.Name = department.Name;
            }
        }

        public void Delete(int id)
        {
            var department = GetById(id);
            if (department != null)
            {
                _departments.Remove(department);
            }
        }
    }
}
