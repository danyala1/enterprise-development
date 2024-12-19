using UniversityData.Domain.Repository;
using UniversityData.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class SpecialtyRepository : ISpecialtyRepository
{
    private readonly UniversityDataDbContext _dbContext;
    private readonly DbSet<Specialty> _specialtySet;

    public SpecialtyRepository(UniversityDataDbContext dbContext)
    {
        _dbContext = dbContext;
        _specialtySet = _dbContext.Specialties;
    }

    /// <summary>
    /// Добавить новую специальность.
    /// </summary>
    public async Task AddAsync(Specialty specialty)
    {
        if (specialty == null) throw new ArgumentNullException(nameof(specialty));

        await _specialtySet.AddAsync(specialty);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Обновить существующую специальность.
    /// </summary>
    public async Task UpdateAsync(Specialty specialty)
    {
        if (specialty == null) throw new ArgumentNullException(nameof(specialty));

        var existingSpecialty = await GetByIdAsync(specialty.Id);
        if (existingSpecialty != null)
        {
            existingSpecialty.Name = specialty.Name;
            existingSpecialty.Code = specialty.Code;

            await _dbContext.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Удалить специальность по идентификатору.
    /// </summary>
    public async Task DeleteAsync(int id)
    {
        var specialtyToRemove = await GetByIdAsync(id);
        if (specialtyToRemove != null)
        {
            _specialtySet.Remove(specialtyToRemove);
            await _dbContext.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Получить специальность по идентификатору.
    /// </summary>
    public async Task<Specialty?> GetByIdAsync(int id)
    {
        return await _specialtySet.FindAsync(id);
    }

    /// <summary>
    /// Получить все специальности.
    /// </summary>
    public async Task<IEnumerable<Specialty>> GetAllAsync()
    {
        return await _specialtySet.ToListAsync();
    }

    /// <summary>
    /// Получить топ-5 популярных специальностей по количеству групп.
    /// </summary>
    public async Task<IEnumerable<Specialty>> GetTopFiveSpecialtiesAsync()
    {
        return await _dbContext.Specialties
            .OrderByDescending(s => s.CountGroups)
            .Take(5)
            .ToListAsync();
    }

}
