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
        _rectors.AddRange(GetInitialRectors());
    }

    private IEnumerable<Rector> GetInitialRectors()
    {
        return new List<Rector>
    {
        new Rector
        {
            Id = 0,
            Name = "Владимир",
            Surname = "Богатырев",
            Patronymic = "Дмитриевич",
            Degree = "Доктор экономических наук",
            Title = "Профессор",
            Position = "Ректор"
        },
        new Rector
        {
            Id = 1,
            Name = "Дмитрий",
            Surname = "Быков",
            Patronymic = "Евгеньевич",
            Degree = "Доктор технических наук",
            Title = "Профессор",
            Position = "Ректор"
        },
        new Rector
        {
            Id = 2,
            Name = "Вадим",
            Surname = "Ружников",
            Patronymic = "Александрович",
            Degree = "Кандидат технических наук",
            Title = "Доцент",
            Position = "Ректор"
        }
    };
    }

    public void Add(Rector rector)
    {
        if (rector == null) throw new ArgumentNullException(nameof(rector));

        rector.Id = _rectors.Count; 
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