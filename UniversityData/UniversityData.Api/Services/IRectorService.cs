using UniversityData.Domain;

namespace Api
{
    public interface IRectorService
    {
        List<Rector> GetAll();
        Rector? GetById(int id);
        void Create(Rector rector);
        void Update(int id, Rector rector);
        void Delete(int id);
    }
}
