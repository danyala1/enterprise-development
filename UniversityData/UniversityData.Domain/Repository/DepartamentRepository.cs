using UniversityData.Domain.Repository;
using UniversityData.Domain;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly List<Department> _departments;

    public DepartmentRepository()
    {
        _departments = new List<Department>();
        InitializeDepartments();
    }

    private void InitializeDepartments()
    {
        for (var i = 0; i < 4; ++i)
        {
            _departments.Add(new Department { Id = i });
        }

        _departments[0].Name = "ГИиБ";
        _departments[0].SupervisorNumber = "890918734";
        _departments[0].UniversityId = 0;

        _departments[1].Name = "Кафедры алгебры и геометрии";
        _departments[1].SupervisorNumber = "890918735";
        _departments[1].UniversityId = 0;

        _departments[2].Name = "Кафедра высшей математики";
        _departments[2].SupervisorNumber = "890918736";
        _departments[2].UniversityId = 1;

        _departments[3].Name = "Кафедра информационных технологий";
        _departments[3].SupervisorNumber = "890918737";
        _departments[3].UniversityId = 2;
    }

    public void Add(Department department)
    {
        if (department == null) throw new ArgumentNullException(nameof(department));

        department.Id = _departments.Count; // Присвоение нового ID
        _departments.Add(department);
    }

    public void Update(Department department)
    {
        var existingDepartment = GetById(department.Id);
        if (existingDepartment != null)
        {
            existingDepartment.Name = department.Name;
            existingDepartment.SupervisorNumber = department.SupervisorNumber;
            existingDepartment.UniversityId = department.UniversityId;
        }
    }

    public void Delete(int id)
    {
        var departmentToRemove = GetById(id);
        if (departmentToRemove != null)
            _departments.Remove(departmentToRemove);
    }

    public Department GetById(int id)
    {
        return _departments.FirstOrDefault(d => d.Id == id);
    }

    public IEnumerable<Department> GetAll()
    {
        return new List<Department>(_departments);
    }
}