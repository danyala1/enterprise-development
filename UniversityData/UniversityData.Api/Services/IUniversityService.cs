using Api.Dto;
using UniversityData.Domain;

namespace Api
{
    public interface IUniversityService
    {
        // CRUD операции
        List<UniversityDto> GetAll();              // Должно возвращать список DTO
        UniversityDto? GetById(int id);             // Должно возвращать DTO
        void Create(University university);        // Создание сущности (не изменяется)
        void Update(int id, University university); // Обновление сущности (не изменяется)
        void Delete(int id);                        // Удаление сущности (не изменяется)

        // Аналитические запросы
        List<UniversityDto> GetTopUniversitiesByDepartments();  // Топ университетов по кафедрам
        List<SpecialtyDto> GetTop5SpecialtiesByGroups();        // Топ 5 специальностей по количеству групп
        List<UniversityDto> GetUniversitiesByOwnership(string ownership); // Университеты по типу собственности
        Dictionary<string, (int faculties, int departments, int specialties)> GetSummaryByOwnership(); // Резюме по собственности
    }
}
