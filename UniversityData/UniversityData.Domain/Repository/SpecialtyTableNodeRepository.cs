using UniversityData.Domain.Repository;
using UniversityData.Domain;
using System.Collections.Generic;
using System.Linq;

public class SpecialtyTableNodeRepository : ISpecialtyTableNodeRepository
{
    private readonly List<SpecialtyTableNode> _specialtyTableNodes;
    private readonly List<Specialty> _specialties;

    public SpecialtyTableNodeRepository(List<Specialty> specialties)
    {
        _specialtyTableNodes = new List<SpecialtyTableNode>();
        _specialties = specialties;
        InitializeSpecialtyTableNodes();
    }

    private void InitializeSpecialtyTableNodes()
    {
        _specialtyTableNodes.AddRange(GetInitialSpecialtyTableNodes());
    }

    public async Task<IEnumerable<SpecialtyTableNode>> GetTopFiveSpecialtiesAsync()
    {
        return await Task.FromResult(_specialtyTableNodes.OrderByDescending(s => s.CountGroups).Take(5).ToList());
    }

    private IEnumerable<SpecialtyTableNode> GetInitialSpecialtyTableNodes()
    {
        return new List<SpecialtyTableNode>
    {
        new SpecialtyTableNode
        {
            Id = 0,
            Specialty = _specialties[0],
            CountGroups = 8,
            UniversityId = 0,
            SpecialtyId = 0
        },
        new SpecialtyTableNode
        {
            Id = 1,
            Specialty = _specialties[0],
            CountGroups = 17,
            UniversityId = 0,
            SpecialtyId = 0
        },
        new SpecialtyTableNode
        {
            Id = 2,
            Specialty = _specialties[1],
            CountGroups = 6,
            UniversityId = 0,
            SpecialtyId = 1
        },
        new SpecialtyTableNode
        {
            Id = 3,
            Specialty = _specialties[1],
            CountGroups = 6,
            UniversityId = 1,
            SpecialtyId = 1
        },
        new SpecialtyTableNode
        {
            Id = 4,
            Specialty = _specialties[2],
            CountGroups = 9,
            UniversityId = 1,
            SpecialtyId = 2
        },
        new SpecialtyTableNode
        {
            Id = 5,
            Specialty = _specialties[2],
            CountGroups = 4,
            UniversityId = 1,
            SpecialtyId = 2
        },
        new SpecialtyTableNode
        {
            Id = 6,
            Specialty = _specialties[3],
            CountGroups = 8,
            UniversityId = 1,
            SpecialtyId = 3
        },
        new SpecialtyTableNode
        {
            Id = 7,
            Specialty = _specialties[3],
            CountGroups = 8,
            UniversityId = 2,
            SpecialtyId = 3
        },
        new SpecialtyTableNode
        {
            Id = 8,
            Specialty = _specialties[4],
            CountGroups = 10,
            UniversityId = 2,
            SpecialtyId = 4
        },
        new SpecialtyTableNode
        {
            Id = 9,
            Specialty = _specialties[4],
            CountGroups = 8,
            UniversityId = 2,
            SpecialtyId = 4
        },
        new SpecialtyTableNode
        {
            Id = 10,
            Specialty = _specialties[4],
            CountGroups = 8,
            UniversityId = 2,
            SpecialtyId = 4
        }
    };
    }

    public void Add(SpecialtyTableNode specialtyTableNode)
    {
        if (specialtyTableNode == null) throw new ArgumentNullException(nameof(specialtyTableNode));

        specialtyTableNode.Id = _specialtyTableNodes.Count;
        _specialtyTableNodes.Add(specialtyTableNode);
    }

    public void Update(SpecialtyTableNode specialtyTableNode)
    {
        var existingNode = GetById(specialtyTableNode.Id);
        if (existingNode != null)
        {
            existingNode.Specialty = specialtyTableNode.Specialty;
            existingNode.CountGroups = specialtyTableNode.CountGroups;
            existingNode.UniversityId = specialtyTableNode.UniversityId;
            existingNode.SpecialtyId = specialtyTableNode.SpecialtyId;
        }
    }

    public void Delete(int id)
    {
        var nodeToRemove = GetById(id);
        if (nodeToRemove != null)
            _specialtyTableNodes.Remove(nodeToRemove);
    }

    public SpecialtyTableNode GetById(int id)
    {
        return _specialtyTableNodes.FirstOrDefault(n => n.Id == id);
    }

    public IEnumerable<SpecialtyTableNode> GetAll()
    {
        return new List<SpecialtyTableNode>(_specialtyTableNodes);
    }
}
