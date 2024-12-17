using UniversityData.Domain.Repository;
using UniversityData.Domain;

public class RectorRepository : IRectorRepository
{
    private readonly List<Rector> _rectors;

    public RectorRepository()
    {
        _rectors = new List<Rector>();
        InitializeRectors();
    }

    private void InitializeRectors()
    {
        for (var i = 0; i < 3; ++i)
        {
            _rectors.Add(new Rector { Id = i });
        }

        _rectors[0].Name = "Владимир";
        _rectors[0].Surname = "Богатырев";
        _rectors[0].Patronymic = "Дмитриевич";
        _rectors[0].Degree = "Доктор экономических наук";
        _rectors[0].Title = "Профессор";
        _rectors[0].Position = "Ректор";

        _rectors[1].Name = "Дмитрий";
        _rectors[1].Surname = "Быков";
        _rectors[1].Patronymic = "Евгеньевич";
        _rectors[1].Degree = "Доктор технических наук";
        _rectors[1].Title = "Профессор";
        _rectors[1].Position = "Ректор";

        _rectors[2].Name = "Вадим";
        _rectors[2].Surname = "Ружников";
        _rectors[2].Patronymic = "Александрович";
        _rectors[2].Degree = "Кандидат технических наук";
        _rectors[2].Title = "Доцент";
        _rectors[2].Position = "Ректор";
    }

    public void Add(Rector rector)
    {
        if (rector == null) throw new ArgumentNullException(nameof(rector));

        rector.Id = _rectors.Count; // Присвоение нового ID
        _rectors.Add(rector);
    }

    public void Update(Rector rector)
    {
        var existingRector = GetById(rector.Id);
        if (existingRector != null)
        {
            existingRector.Name = rector.Name;
            existingRector.Surname = rector.Surname;
            existingRector.Patronymic = rector.Patronymic;
            existingRector.Degree = rector.Degree;
            existingRector.Title = rector.Title;
            existingRector.Position = rector.Position;
        }
    }

    public void Delete(int id)
    {
        var rectorToRemove = GetById(id);
        if (rectorToRemove != null)
            _rectors.Remove(rectorToRemove);
    }

    public Rector GetById(int id)
    {
        return _rectors.FirstOrDefault(r => r.Id == id);
    }

    public IEnumerable<Rector> GetAll()
    {
        return new List<Rector>(_rectors);
    }
}