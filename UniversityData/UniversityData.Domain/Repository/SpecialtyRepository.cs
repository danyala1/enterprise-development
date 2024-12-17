using UniversityData.Domain.Repository;
using UniversityData.Domain;

public class SpecialtyRepository : ISpecialtyRepository
{
    private readonly List<Specialty> _specialties;

    public SpecialtyRepository()
    {
        _specialties = new List<Specialty>();
        InitializeSpecialties();
    }

    private void InitializeSpecialties()
    {
        for (var i = 0; i < 5; ++i)
        {
            _specialties.Add(new Specialty { Id = i });
        }

        _specialties[0].Name = "Прикладная информатика";
        _specialties[0].Code = "09.03.03";

        _specialties[1].Name = "Информационные системы и технологии";
        _specialties[1].Code = "09.03.02";

        _specialties[2].Name = "Информатика и вычислительная техника";
        _specialties[2].Code = "09.03.01";

        _specialties[3].Name = "Прикладная математика и информатика";
        _specialties[3].Code = "01.03.02";

        _specialties[4].Name = "Информационная безопасность автоматизированных систем";
        _specialties[4].Code = "10.05.03";
    }

    public void Add(Specialty specialty)
    {
        if (specialty == null) throw new ArgumentNullException(nameof(specialty));

        specialty.Id = _specialties.Count; // Присвоение нового ID
        _specialties.Add(specialty);
    }

    public void Update(Specialty specialty)
    {
        var existingSpecialty = GetById(specialty.Id);
        if (existingSpecialty != null)
        {
            existingSpecialty.Name = specialty.Name;
            existingSpecialty.Code = specialty.Code;
        }
    }

    public void Delete(int id)
    {
        var specialtyToRemove = GetById(id);
        if (specialtyToRemove != null)
            _specialties.Remove(specialtyToRemove);
    }

    public Specialty GetById(int id)
    {
        return _specialties.FirstOrDefault(s => s.Id == id);
    }

    public IEnumerable<Specialty> GetAll()
    {
        return new List<Specialty>(_specialties);
    }
}
