namespace UniversityData.Domain.Repository;
public interface IFacultyRepository
{
    void Add(Faculty faculty);
    void Update(Faculty faculty);
    void Delete(int id);
    Faculty GetById(int id);
    IEnumerable<Faculty> GetAll();
}

public interface IRectorRepository
{
    void Add(Rector rector);
    void Update(Rector rector);
    void Delete(int id);
    Rector GetById(int id);
    IEnumerable<Rector> GetAll();
}

public interface ISpecialtyRepository
{
    void Add(Specialty specialty);
    void Update(Specialty specialty);
    void Delete(int id);
    Specialty GetById(int id);
    IEnumerable<Specialty> GetAll();
}

public interface IDepartmentRepository
{
    void Add(Department department);
    void Update(Department department);
    void Delete(int id);
    Department GetById(int id);
    IEnumerable<Department> GetAll();
}

public interface ISpecialtyTableNodeRepository
{
    void Add(SpecialtyTableNode specialtyTableNode);
    void Update(SpecialtyTableNode specialtyTableNode);
    void Delete(int id);
    SpecialtyTableNode GetById(int id);
    IEnumerable<SpecialtyTableNode> GetAll();
}

public interface IUniversityRepository
{
    void Add(University university);
    void Update(University university);
    void Delete(int id);
    University GetById(int id);
    IEnumerable<University> GetAll();
}
