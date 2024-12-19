using UniversityData.Domain.Repository;
using UniversityData.Domain;
using Microsoft.EntityFrameworkCore;

public class UniversityRepository : IUniversityRepository
{
    private readonly UniversityDataDbContext _dbContext;
    private readonly DbSet<University> _universities;

    public UniversityRepository(UniversityDataDbContext dbContext)
    {
        _dbContext = dbContext;
        _universities = _dbContext.Universities;
    }

    public async Task<University?> GetByNumberAsync(string number)
    {
        return await _universities
            .Include(u => u.RectorData)
            .Include(u => u.UniversityProperty)
            .Include(u => u.ConstructionProperty)
            .FirstOrDefaultAsync(u => u.Number == number);
    }

    public async Task<IEnumerable<University>> GetUniversitiesWithMaxDepartmentsAsync()
    {
        var maxDepartmentCount = await _universities.MaxAsync(u => u.DepartmentsData.Count);
        return await _universities
            .Where(u => u.DepartmentsData.Count == maxDepartmentCount)
            .Include(u => u.DepartmentsData)
            .ToListAsync();
    }

    public async Task<IEnumerable<University>> GetUniversitiesWithPropertyAsync(int universityPropertyId)
    {
        return await _universities
            .Where(u => u.UniversityProperty != null && 
                        u.UniversityProperty.Id == universityPropertyId)
            .Include(u => u.UniversityProperty)
            .ToListAsync();
    }

    public async Task AddAsync(University university)
    {
        if (university == null) throw new ArgumentNullException(nameof(university));

        await _universities.AddAsync(university);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(University university)
    {
        if (university == null) throw new ArgumentNullException(nameof(university));

        var existingUniversity = await GetByIdAsync(university.Id);
        if (existingUniversity != null)
        {
            existingUniversity.Number = university.Number;
            existingUniversity.Name = university.Name;
            existingUniversity.Address = university.Address;
            existingUniversity.RectorData = university.RectorData;
            existingUniversity.UniversityProperty = university.UniversityProperty;
            existingUniversity.ConstructionProperty = university.ConstructionProperty;
            existingUniversity.RectorId = university.RectorId;

            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var universityToRemove = await GetByIdAsync(id);
        if (universityToRemove != null)
        {
            _universities.Remove(universityToRemove);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<University?> GetByIdAsync(int id)
    {
        return await _universities
            .Include(u => u.RectorData)
            .Include(u => u.UniversityProperty)
            .Include(u => u.ConstructionProperty)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<University?>> GetAllAsync()
    {
        return await _universities
            .Include(u => u.RectorData)
            .Include(u => u.UniversityProperty)
            .Include(u => u.ConstructionProperty)
            .ToListAsync();
    }


    /// <summary>
    /// Получить максимальное количество кафедр среди университетов.
    /// </summary>
    public async Task<int> GetMaxDepartmentCountAsync()
    {
        return await _universities.MaxAsync(u => u.DepartmentsData.Count);
    }

    /// <summary>
    /// Получить университеты по идентификатору собственности.
    /// </summary>
    public async Task<List<University>> GetUniversitiesByPropertyIdAsync(int universityPropertyId)
    {
        return await _universities
            .Where(u => u.UniversityProperty != null&&
                    u.UniversityProperty.Id == universityPropertyId)

            .Include(u => u.UniversityProperty)
            .ToListAsync();
    }

    /// <summary>
    /// Получить университеты, отсортированные по количеству кафедр.
    /// </summary>
    public async Task<IEnumerable<University>> GetUniversitiesByDepartmentCountAsync()
    {
        return await _universities
            .OrderByDescending(u => u.DepartmentsData.Count)
            .Include(u => u.DepartmentsData)
            .ToListAsync();
    }
}
