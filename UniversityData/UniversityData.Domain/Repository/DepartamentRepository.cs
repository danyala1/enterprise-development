using UniversityData.Domain.Repository;
using UniversityData.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly UniversityDataDbContext _dbContext;
    private readonly DbSet<Department> _departments;

    public DepartmentRepository(UniversityDataDbContext dbContext)
    {
        _dbContext = dbContext;
        _departments = _dbContext.Departments;
    }

    /// <summary>
    /// Добавить новый отдел.
    /// </summary>
    public async Task AddAsync(Department department)
    {
        if (department == null) throw new ArgumentNullException(nameof(department));

        await _departments.AddAsync(department);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Обновить существующий отдел.
    /// </summary>
    public async Task UpdateAsync(Department department)
    {
        if (department == null) throw new ArgumentNullException(nameof(department));

        var existingDepartment = await GetByIdAsync(department.Id);
        if (existingDepartment != null)
        {
            existingDepartment.Name = department.Name;
            existingDepartment.SupervisorNumber = department.SupervisorNumber;
            existingDepartment.UniversityId = department.UniversityId;

            await _dbContext.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Удалить отдел по идентификатору.
    /// </summary>
    public async Task DeleteAsync(int id)
    {
        var departmentToRemove = await GetByIdAsync(id);
        if (departmentToRemove != null)
        {
            _departments.Remove(departmentToRemove);
            await _dbContext.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Получить отдел по идентификатору.
    /// </summary>
    public async Task<Department?> GetByIdAsync(int id)
    {
        return await _departments.FindAsync(id);
    }

    /// <summary>
    /// Получить всех сотрудников.
    /// </summary>
    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        return await _departments.ToListAsync();
    }
}