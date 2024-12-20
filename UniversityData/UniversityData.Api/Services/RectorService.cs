using Microsoft.EntityFrameworkCore;
using UniversityData.Domain;
using UniversityData.Api.Services.Interfaces;

namespace UniversityData.Api.Services;

/// <summary>
/// Сервис для управления ректорами.
/// </summary>
public class RectorService : IRectorService
{
    private readonly UniversityDbContext _context;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="RectorService"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public RectorService(UniversityDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получает всех ректоров.
    /// </summary>
    /// <returns>Список всех ректоров.</returns>
    public List<Rector> GetAll()
    {
        return _context.Rectors.ToList();
    }

    /// <summary>
    /// Получает ректора по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор ректора.</param>
    /// <returns>Ректор с указанным идентификатором или <c>null</c>, если не найден.</returns>
    public Rector? GetById(int id)
    {
        return _context.Rectors
            .Include(r => r.University)
            .FirstOrDefault(r => r.Id == id);
    }

    /// <summary>
    /// Создает нового ректора.
    /// </summary>
    /// <param name="rector">Данные нового ректора.</param>
    public void Create(Rector rector)
    {
        _context.Rectors.Add(rector);
        _context.SaveChanges();
    }

    /// <summary>
    /// Обновляет существующего ректора.
    /// </summary>
    /// <param name="id">Идентификатор ректора для обновления.</param>
    /// <param name="rector">Обновленные данные ректора.</param>
    public void Update(int id, Rector rector)
    {
        var existingRector = GetById(id);
        if (existingRector != null)
        {
            existingRector.FullName = rector.FullName;
            existingRector.Degree = rector.Degree;
            existingRector.Title = rector.Title;
            existingRector.Position = rector.Position;

            _context.SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException($"Ректор с ID {id} не найден.");
        }
    }

    /// <summary>
    /// Удаляет ректора по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор ректора для удаления.</param>
    public void Delete(int id)
    {
        var rector = GetById(id);
        if (rector != null)
        {
            _context.Rectors.Remove(rector);
            _context.SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException($"Ректор с ID {id} не найден.");
        }
    }
}
