﻿using UniversityData.Domain.Repository;
using UniversityData.Domain;

public class SpecialtyRepository : ISpecialtyRepository
{
    private readonly List<Specialty> _specialties;

    public SpecialtyRepository()
    {
        _specialties = new List<Specialty>();
        InitializeSpecialties();
    }

    private void InitializeSpecialties()
    {
        _specialties.AddRange(GetInitialSpecialties());
    }

    private IEnumerable<Specialty> GetInitialSpecialties()
    {
        return new List<Specialty>
        {
            new Specialty { Id = 0, Name = "Прикладная информатика", Code = "09.03.03" },
            new Specialty { Id = 1, Name = "Информационные системы и технологии", Code = "09.03.02" },
            new Specialty { Id = 2, Name = "Информатика и вычислительная техника", Code = "09.03.01" },
            new Specialty { Id = 3, Name = "Прикладная математика и информатика", Code = "01.03.02" },
            new Specialty { Id = 4, Name = "Информационная безопасность автоматизированных систем", Code = "10.05.03" }
        };
    }

    public void Add(Specialty specialty)
    {
        if (specialty == null) throw new ArgumentNullException(nameof(specialty));

        specialty.Id = _specialties.Count; 
        _specialties.Add(specialty);
    }

    public void Update(Specialty specialty)
    {
        var existingSpecialty = GetById(specialty.Id);
        if (existingSpecialty != null)
        {
            existingSpecialty.Name = specialty.Name;
            existingSpecialty.Code = specialty.Code;
        }
    }

    public void Delete(int id)
    {
        var specialtyToRemove = GetById(id);
        if (specialtyToRemove != null)
            _specialties.Remove(specialtyToRemove);
    }

    public Specialty GetById(int id)
    {
        return _specialties.FirstOrDefault(s => s.Id == id);
    }

    public IEnumerable<Specialty> GetAll()
    {
        return new List<Specialty>(_specialties);
    }
}
