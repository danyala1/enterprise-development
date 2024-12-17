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
        _departments.AddRange(GetInitialDepartments());
    }

    private IEnumerable<Department> GetInitialDepartments()
    {
        return new List<Department>
    {
        new Department
        {
            Id = 0,
            Name = "ГИиБ",
            SupervisorNumber = "890918734",
            UniversityId = 0
        },
        new Department
        {
            Id = 1,
            Name = "Кафедры алгебры и геометрии",
            SupervisorNumber = "890918735",
            UniversityId = 0
        },
        new Department
        {
            Id = 2,
            Name = "Кафедра высшей математики",
            SupervisorNumber = "890918736",
            UniversityId = 1
        },
        new Department
        {
            Id = 3,
            Name = "Кафедра информационных технологий",
            SupervisorNumber = "890918737",
            UniversityId = 2
        }
    };
    }

    public void Add(Department department)
    {
        if (department == null) throw new ArgumentNullException(nameof(department));

        department.Id = _departments.Count; 
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