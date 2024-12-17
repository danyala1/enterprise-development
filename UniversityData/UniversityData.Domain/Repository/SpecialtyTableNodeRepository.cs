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
        _specialties = specialties; // Инициализация специальностей
        InitializeSpecialtyTableNodes();
    }

    private void InitializeSpecialtyTableNodes()
    {
        for (var i = 0; i < 11; ++i)
        {
            _specialtyTableNodes.Add(new SpecialtyTableNode { Id = i });
        }

        // Инициализация узлов таблицы специальностей
        _specialtyTableNodes[0].Specialty = _specialties[0];
        _specialtyTableNodes[0].CountGroups = 8;
        _specialtyTableNodes[0].UniversityId = 0;
        _specialtyTableNodes[0].SpecialtyId = 0;

        _specialtyTableNodes[1].Specialty = _specialties[0];
        _specialtyTableNodes[1].CountGroups = 17;
        _specialtyTableNodes[1].UniversityId = 0;
        _specialtyTableNodes[1].SpecialtyId = 0;

        _specialtyTableNodes[2].Specialty = _specialties[1];
        _specialtyTableNodes[2].CountGroups = 6;
        _specialtyTableNodes[2].UniversityId = 0;
        _specialtyTableNodes[2].SpecialtyId = 1;

        // Продолжайте инициализацию для остальных узлов...
    }

    public void Add(SpecialtyTableNode specialtyTableNode)
    {
        if (specialtyTableNode == null) throw new ArgumentNullException(nameof(specialtyTableNode));

        specialtyTableNode.Id = _specialtyTableNodes.Count; // Присвоение нового ID
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
