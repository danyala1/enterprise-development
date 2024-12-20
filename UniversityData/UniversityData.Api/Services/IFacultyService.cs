using UniversityData.Domain;

namespace Api
{
    public interface IFacultyService
    {
        List<Faculty> GetAll();
        Faculty? GetById(int id);
        void Create(Faculty faculty);
        void Update(int id, Faculty faculty);
        void Delete(int id);
    }
}
