
namespace UniversityData.Domain.Repository;
public interface IFacultyRepository
{
    Task AddAsync(Faculty faculty);
    Task UpdateAsync(Faculty faculty);
    Task DeleteAsync(int id);
    Task<Faculty?> GetByIdAsync(int id);
    Task<IEnumerable<Faculty>> GetAllAsync();
}

public interface IRectorRepository
{
    Task AddAsync(Rector rector);
    Task UpdateAsync(Rector rector);
    Task DeleteAsync(int id);
    Task<Rector?> GetByIdAsync(int id);
    Task<IEnumerable<Rector>> GetAllAsync();
}

public interface ISpecialtyRepository
{
    Task AddAsync(Specialty specialty);
    Task UpdateAsync(Specialty specialty);
    Task DeleteAsync(int id);
    Task<Specialty?> GetByIdAsync(int id);
    Task<IEnumerable<Specialty>> GetAllAsync();
    Task<IEnumerable<Specialty>> GetTopFiveSpecialtiesAsync();
}

public interface IDepartmentRepository
{
    Task AddAsync(Department department);
    Task UpdateAsync(Department department);
    Task DeleteAsync(int id);
    Task<Department?> GetByIdAsync(int id);
    Task<IEnumerable<Department>> GetAllAsync();
}

public interface ISpecialtyTableNodeRepository
{
    Task<IEnumerable<SpecialtyTableNode>> GetTopFiveSpecialtiesAsync();
    Task AddAsync(SpecialtyTableNode specialtyTableNode);
    Task UpdateAsync(SpecialtyTableNode specialtyTableNode);
    Task DeleteAsync(int id);
    Task<SpecialtyTableNode?> GetByIdAsync(int id);
    Task<IEnumerable<SpecialtyTableNode>> GetAllAsync();
}

public interface IUniversityRepository
{
    Task<int> GetMaxDepartmentCountAsync();
    Task<List<University>> GetUniversitiesByPropertyIdAsync(int universityPropertyId);
    Task<IEnumerable<University>> GetUniversitiesByDepartmentCountAsync();
    Task<University?> GetByNumberAsync(string number);
    Task<IEnumerable<University>> GetUniversitiesWithMaxDepartmentsAsync();
    Task<IEnumerable<University>> GetUniversitiesWithPropertyAsync(int universityPropertyId);
    Task AddAsync(University university);
    Task UpdateAsync(University university);
    Task DeleteAsync(int id);
    Task<University?> GetByIdAsync(int id);
    Task<IEnumerable<University?>> GetAllAsync();
}