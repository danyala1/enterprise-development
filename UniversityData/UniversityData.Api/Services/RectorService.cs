using UniversityData.Domain;
using System.Xml.Linq;

namespace Api
{
    public class RectorService : IRectorService
    {
        private readonly List<Rector> _rectors = new();

        public List<Rector> GetAll()
        {
            return _rectors;
        }

        public Rector? GetById(int id)
        {
            return _rectors.FirstOrDefault(r => r.Id == id);
        }

        public void Create(Rector rector)
        {
            _rectors.Add(rector);
        }

        public void Update(int id, Rector rector)
        {
            var existingRector = GetById(id);
            if (existingRector != null)
            {
                existingRector.FullName = rector.FullName;
                existingRector.Degree = rector.Degree;
                existingRector.Position = rector.Position;
            }
        }

        public void Delete(int id)
        {
            var rector = GetById(id);
            if (rector != null)
            {
                _rectors.Remove(rector);
            }
        }
    }
}
