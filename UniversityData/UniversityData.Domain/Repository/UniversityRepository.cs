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
        foreach (var university in GetInitialUniversities())
        {
            _universities.Add(university);
        }
    }

    private IEnumerable<University> GetInitialUniversities()
    {
        return new List<University>
        {
            new University
            {
                Id = 0,
                Number = "12345",
                Name = "Самарский университет",
                Address = "Самара",
                RectorData = _rectors[0],
                UniversityProperty = _universityProperties[0],
                ConstructionProperty = _constructionProperties[0],
                RectorId = 0
            },
            new University
            {
                Id = 1,
                Number = "56789",
                Name = "СамГТУ",
                Address = "Самара",
                RectorData = _rectors[1],
                UniversityProperty = _universityProperties[0],
                ConstructionProperty = _constructionProperties[0],
                RectorId = 1
            },
            new University
            {
                Id = 2,
                Number = "45678",
                Name = "ПГУТИ",
                Address = "Самара",
                RectorData = _rectors[2],
                UniversityProperty = _universityProperties[0],
                ConstructionProperty = _constructionProperties[2],
                RectorId = 2
            }
        };
    }

    private void InitializeFacultiesAndDepartments()
    {
        _universities[0].FacultiesData.AddRange(new Faculty[] { _faculties[0], _faculties[1], _faculties[2] });
        _universities[0].DepartmentsData.AddRange(new Department[] { _departments[0], _departments[1] });
        _universities[0].SpecialtyTable.AddRange(new SpecialtyTableNode[] { _specialtyTableNodes[0], _specialtyTableNodes[1], _specialtyTableNodes[2] });

        _universities[1].FacultiesData.AddRange(new Faculty[] { _faculties[3], _faculties[4] });
        _universities[1].DepartmentsData.AddRange(new Department[] { _departments[2] });
        _universities[1].SpecialtyTable.AddRange(new SpecialtyTableNode[] { _specialtyTableNodes[3], _specialtyTableNodes[4], _specialtyTableNodes[5], _specialtyTableNodes[6] });

        _universities[2].FacultiesData.AddRange(new Faculty[] { _faculties[5] });
        _universities[2].DepartmentsData.AddRange(new Department[] { _departments[3] });
        _universities[2].SpecialtyTable.AddRange(new SpecialtyTableNode[] { _specialtyTableNodes[7], _specialtyTableNodes[8], _specialtyTableNodes[9], _specialtyTableNodes[10] });
    }

    public void Add(University university)
    {
        if (university == null) throw new ArgumentNullException(nameof(university));

        university.Id = _universities.Count; 
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
