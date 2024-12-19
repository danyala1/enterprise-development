using UniversityData.Domain.Repository;
using UniversityData.Domain;
using Microsoft.EntityFrameworkCore;

public class SpecialtyTableNodeRepository : ISpecialtyTableNodeRepository
{
    private readonly UniversityDataDbContext _dbContext;
    private readonly DbSet<SpecialtyTableNode> _specialtyTableNodes;

    public SpecialtyTableNodeRepository(UniversityDataDbContext dbContext)
    {
        _dbContext = dbContext;
        _specialtyTableNodes = _dbContext.SpecialtyTableNodes;
    }

    public async Task<IEnumerable<SpecialtyTableNode>> GetTopFiveSpecialtiesAsync()
    {
        return await _specialtyTableNodes
            .OrderByDescending(s => s.CountGroups)
            .Take(5)
            .ToListAsync();
    }

    public async Task AddAsync(SpecialtyTableNode specialtyTableNode)
    {
        if (specialtyTableNode == null) throw new ArgumentNullException(nameof(specialtyTableNode));

        await _specialtyTableNodes.AddAsync(specialtyTableNode);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(SpecialtyTableNode specialtyTableNode)
    {
        if (specialtyTableNode == null) throw new ArgumentNullException(nameof(specialtyTableNode));

        var existingNode = await GetByIdAsync(specialtyTableNode.Id);
        if (existingNode != null)
        {
            existingNode.Specialty = specialtyTableNode.Specialty;
            existingNode.CountGroups = specialtyTableNode.CountGroups;
            existingNode.UniversityId = specialtyTableNode.UniversityId;
            existingNode.SpecialtyId = specialtyTableNode.SpecialtyId;

            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var nodeToRemove = await GetByIdAsync(id);
        if (nodeToRemove != null)
        {
            _specialtyTableNodes.Remove(nodeToRemove);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<SpecialtyTableNode?> GetByIdAsync(int id)
    {
        return await _specialtyTableNodes.FindAsync(id);
    }

    public async Task<IEnumerable<SpecialtyTableNode>> GetAllAsync()
    {
        return await _specialtyTableNodes.ToListAsync();
    }
}
