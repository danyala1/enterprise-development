using Microsoft.EntityFrameworkCore;
using UniversityData.Domain;
using UniversityData.Api.Services.Interfaces;

namespace UniversityData.Api.Services
{
    /// <summary>
    /// Сервис для управления специальностями.
    /// </summary>
    public class SpecialtyService : IEntityService<Specialty>
    {
        private readonly UniversityDbContext _context;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="SpecialtyService"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        public SpecialtyService(UniversityDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает все специальности.
        /// </summary>
        /// <returns>Список всех специальностей.</returns>
        public List<Specialty> GetAll()
        {
            return _context.Specialties
                .ToList();
        }

        /// <summary>
        /// Получает специальность по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор специальности.</param>
        /// <returns>Специальность с указанным идентификатором или <c>null</c>, если не найдена.</returns>
        public Specialty? GetById(int id)
        {
            return _context.Specialties
                .FirstOrDefault(s => s.Id == id);
        }

        /// <summary>
        /// Создает новую специальность.
        /// </summary>
        /// <param name="specialty">Данные новой специальности.</param>
        public void Create(Specialty specialty)
        {
            _context.Specialties.Add(specialty);
            _context.SaveChanges();
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
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Специальность с ID {id} не найдена.");
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
                _context.Specialties.Remove(specialty);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Специальность с ID {id} не найдена.");
            }
        }
    }
}