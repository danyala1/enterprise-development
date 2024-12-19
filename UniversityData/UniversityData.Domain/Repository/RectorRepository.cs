using UniversityData.Domain.Repository;
using UniversityData.Domain;
using Microsoft.EntityFrameworkCore;

public class RectorRepository : IRectorRepository
{
    private readonly UniversityDataDbContext _dbContext;
    private readonly DbSet<Rector> _rectors;

    public RectorRepository(UniversityDataDbContext dbContext)
    {
        _dbContext = dbContext;
        _rectors = _dbContext.Rectors;
    }

    /// <summary>
    /// Добавить нового ректора.
    /// </summary>
    public async Task AddAsync(Rector rector)
    {
        if (rector == null) throw new ArgumentNullException(nameof(rector));

        await _rectors.AddAsync(rector);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Обновить существующего ректора.
    /// </summary>
    public async Task UpdateAsync(Rector rector)
    {
        if (rector == null) throw new ArgumentNullException(nameof(rector));

        var existingRector = await GetByIdAsync(rector.Id);
        if (existingRector != null)
        {
            existingRector.Name = rector.Name;
            existingRector.Surname = rector.Surname;
            existingRector.Patronymic = rector.Patronymic;
            existingRector.Degree = rector.Degree;
            existingRector.Title = rector.Title;
            existingRector.Position = rector.Position;

            await _dbContext.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Удалить ректора по идентификатору.
    /// </summary>
    public async Task DeleteAsync(int id)
    {
        var rectorToRemove = await GetByIdAsync(id);
        if (rectorToRemove != null)
        {
            _rectors.Remove(rectorToRemove);
            await _dbContext.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Получить ректора по идентификатору.
    /// </summary>
    public async Task<Rector?> GetByIdAsync(int id)
    {
        return await _rectors.FindAsync(id);
    }

    /// <summary>
    /// Получить всех ректоров.
    /// </summary>
    public async Task<IEnumerable<Rector>> GetAllAsync()
    {
        return await _rectors.ToListAsync();
    }
}
