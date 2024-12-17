using UniversityData.Domain.Repository;
using UniversityData.Domain;

public class UniversityRepository : IUniversityRepository
{
    private readonly List<University> _universities;
    private readonly List<Rector> _rectors;
    private readonly List<UniversityProperty> _universityProperties;
    private readonly List<ConstructionProperty> _constructionProperties;
    private readonly List<Faculty> _faculties;
    private readonly List<Department> _departments;
    private readonly List<SpecialtyTableNode> _specialtyTableNodes;

    public UniversityRepository(
        List<Rector> rectors,
        List<UniversityProperty> universityProperties,
        List<ConstructionProperty> constructionProperties,
        List<Faculty> faculties,
        List<Department> departments,
        List<SpecialtyTableNode> specialtyTableNodes)
    {
        _universities = new List<University>();
        _rectors = rectors;
        _universityProperties = universityProperties;
        _constructionProperties = constructionProperties;
        _faculties = faculties;
        _departments = departments;
        _specialtyTableNodes = specialtyTableNodes;

        InitializeUniversities();
    }

    private void InitializeUniversities()
    {
        for (var i = 0; i < 3; ++i)
        {
            _universities.Add(new University { Id = i });
        }

        // Инициализация университетов
        _universities[0].Number = "12345";
        _universities[0].Name = "Самарский университет";
        _universities[0].Address = "Самара";
        _universities[0].RectorData = _rectors[0];
        _universities[0].UniversityProperty = _universityProperties[0];
        _universities[0].ConstructionProperty = _constructionProperties[0];
        _universities[0].RectorId = 0;

        // Аналогично для других университетов
        // ...

        // Добавление факультетов, кафедр и узлов специальностей
        InitializeFacultiesAndDepartments();
    }

    private void InitializeFacultiesAndDepartments()
    {
        // Пример добавления факультетов и кафедр для университетов
        // Для первого университета
        _universities[0].FacultiesData.AddRange(new Faculty[] { _faculties[0], _faculties[1], _faculties[2] });
        _universities[0].DepartmentsData.AddRange(new Department[] { _departments[0], _departments[1] });
        _universities[0].SpecialtyTable.AddRange(new SpecialtyTableNode[] { _specialtyTableNodes[0], _specialtyTableNodes[1], _specialtyTableNodes[2] });

        // Для второго университета
        // ...

        // Для третьего университета
        // ...
    }

    public void Add(University university)
    {
        if (university == null) throw new ArgumentNullException(nameof(university));

        university.Id = _universities.Count; // Присвоение нового ID
        _universities.Add(university);
    }

    public void Update(University university)
    {
        var existingUniversity = GetById(university.Id);
        if (existingUniversity != null)
        {
            existingUniversity.Number = university.Number;
            existingUniversity.Name = university.Name;
            existingUniversity.Address = university.Address;
            existingUniversity.RectorData = university.RectorData;
            existingUniversity.UniversityProperty = university.UniversityProperty;
            existingUniversity.ConstructionProperty = university.ConstructionProperty;
            existingUniversity.RectorId = university.RectorId;
            // Обновление факультетов, кафедр и узлов специальностей можно добавить по необходимости
        }
    }

    public void Delete(int id)
    {
        var universityToRemove = GetById(id);
        if (universityToRemove != null)
            _universities.Remove(universityToRemove);
    }

    public University GetById(int id)
    {
        return _universities.FirstOrDefault(u => u.Id == id);
    }

    public IEnumerable<University> GetAll()
    {
        return new List<University>(_universities);
    }
}
