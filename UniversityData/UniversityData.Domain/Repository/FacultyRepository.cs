using UniversityData.Domain.Repository;
using UniversityData.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FacultyRepository : IFacultyRepository
{
    private readonly UniversityDataDbContext _dbContext;
    private readonly DbSet<Faculty> _faculties;

    public FacultyRepository(UniversityDataDbContext dbContext)
    {
        _dbContext = dbContext;
        _faculties = _dbContext.Faculties;
    }

    /// <summary>
    /// Добавить новый факультет.
    /// </summary>
    public async Task AddAsync(Faculty faculty)
    {
        if (faculty == null) throw new ArgumentNullException(nameof(faculty));

        await _faculties.AddAsync(faculty);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Обновить существующий факультет.
    /// </summary>
    public async Task UpdateAsync(Faculty faculty)
    {
        if (faculty == null) throw new ArgumentNullException(nameof(faculty));

        var existingFaculty = await GetByIdAsync(faculty.Id);
        if (existingFaculty != null)
        {
            existingFaculty.Name = faculty.Name;
            existingFaculty.WorkersCount = faculty.WorkersCount;
            existingFaculty.StudentsCount = faculty.StudentsCount;
            existingFaculty.UniversityId = faculty.UniversityId;

            await _dbContext.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Удалить факультет по идентификатору.
    /// </summary>
    public async Task DeleteAsync(int id)
    {
        var facultyToRemove = await GetByIdAsync(id);
        if (facultyToRemove != null)
        {
            _faculties.Remove(facultyToRemove);
            await _dbContext.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Получить факультет по идентификатору.
    /// </summary>
    public async Task<Faculty?> GetByIdAsync(int id)
    {
        return await _faculties.FindAsync(id);
    }

    /// <summary>
    /// Получить всех факультетов.
    /// </summary>
    public async Task<IEnumerable<Faculty>> GetAllAsync()
    {
        return await _faculties.ToListAsync();
    }
}
