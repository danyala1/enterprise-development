using UniversityData.Domain;
using System.Xml.Linq;

namespace Api
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly List<Specialty> _specialties = new();

        public List<Specialty> GetAll()
        {
            return _specialties;
        }

        public Specialty? GetById(int id)
        {
            return _specialties.FirstOrDefault(s => s.Id == id);
        }

        public void Create(Specialty specialty)
        {
            _specialties.Add(specialty);
        }

        public void Update(int id, Specialty specialty)
        {
            var existingSpecialty = GetById(id);
            if (existingSpecialty != null)
            {
                existingSpecialty.Name = specialty.Name;
                existingSpecialty.Code = specialty.Code;
                existingSpecialty.GroupCount = specialty.GroupCount;
            }
        }

        public void Delete(int id)
        {
            var specialty = GetById(id);
            if (specialty != null)
            {
                _specialties.Remove(specialty);
            }
        }

        public List<Specialty> GetTopSpecialtiesByGroups()
        {
            return _specialties.OrderByDescending(s => s.GroupCount).Take(5).ToList();
        }
    }
}
