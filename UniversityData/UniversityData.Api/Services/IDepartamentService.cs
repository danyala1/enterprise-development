using UniversityData.Domain;

namespace Api
{
    public interface IDepartmentService
    {
        List<Department> GetAll();
        Department? GetById(int id);
        void Create(Department department);
        void Update(int id, Department department);
        void Delete(int id);
    }
}
