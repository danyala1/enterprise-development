using UniversityData.Domain;

namespace Api
{
    public interface ISpecialtyService
    {
        List<Specialty> GetAll();
        Specialty? GetById(int id);
        void Create(Specialty specialty);
        void Update(int id, Specialty specialty);
        void Delete(int id);
        List<Specialty> GetTopSpecialtiesByGroups();
    }
}
