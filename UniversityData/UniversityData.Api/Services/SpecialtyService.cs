﻿using UniversityData.Domain;
using UniversityData.Api.Services.Interfaces;

namespace UniversityData.Api.Services;

/// <summary>
/// Сервис для управления специальностями.
/// </summary>
public class SpecialtyService : ISpecialtyService
{
    private readonly List<Specialty> _specialties = new();

    /// <summary>
    /// Получает все специальности.
    /// </summary>
    /// <returns>Список всех специальностей.</returns>
    public List<Specialty> GetAll()
    {
        return _specialties;
    }

    /// <summary>
    /// Получает специальность по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор специальности.</param>
    /// <returns>Специальность с указанным идентификатором или <c>null</c>, если не найдена.</returns>
    public Specialty? GetById(int id)
    {
        return _specialties.FirstOrDefault(s => s.Id == id);
    }

    /// <summary>
    /// Создает новую специальность.
    /// </summary>
    /// <param name="specialty">Данные новой специальности.</param>
    public void Create(Specialty specialty)
    {
        _specialties.Add(specialty);
    }

    /// <summary>
    /// Обновляет существующую специальность.
    /// </summary>
    /// <param name="id">Идентификатор специальности для обновления.</param>
    /// <param name="specialty">Обновленные данные специальности.</param>
    public void Update(int id, Specialty specialty)
    {
        var existingSpecialty = GetById(id);
        if (existingSpecialty != null)
        {
            existingSpecialty.Name = specialty.Name;
            existingSpecialty.Code = specialty.Code;
            existingSpecialty.GroupCount = specialty.GroupCount;
        }
    }

    /// <summary>
    /// Удаляет специальность по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор специальности для удаления.</param>
    public void Delete(int id)
    {
        var specialty = GetById(id);
        if (specialty != null)
        {
            _specialties.Remove(specialty);
        }
    }

    /// <summary>
    /// Получает топ специальностей по количеству групп.
    /// </summary>
    /// <returns>Список топ 5 специальностей с наибольшим количеством групп.</returns>
    public List<Specialty> GetTopSpecialtiesByGroups()
    {
        return _specialties.OrderByDescending(s => s.GroupCount).Take(5).ToList();
    }
}
