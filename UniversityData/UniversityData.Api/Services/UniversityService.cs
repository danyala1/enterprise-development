using UniversityData.Domain;
using Api.Dto;
using System.Linq;

namespace Api
{
    public class UniversityService : IUniversityService
    {
        private readonly List<University> _universities = new();

        // CRUD операции
        public List<UniversityDto> GetAll()
        {
            return _universities
                .Select(u => new UniversityDto
                {
                    RegistrationNumber = u.RegistrationNumber,
                    Name = u.Name,
                    Address = u.Address,
                    InstitutionOwnership = u.InstitutionOwnership,
                    BuildingOwnership = u.BuildingOwnership
                })
                .ToList();
        }

        public UniversityDto? GetById(int id)
        {
            var university = _universities.FirstOrDefault(u => u.RegistrationNumber == id);
            if (university == null)
                return null;

            return new UniversityDto
            {
                RegistrationNumber = university.RegistrationNumber,
                Name = university.Name,
                Address = university.Address,
                InstitutionOwnership = university.InstitutionOwnership,
                BuildingOwnership = university.BuildingOwnership
            };
        }

        public void Create(University university)
        {
            _universities.Add(university);
        }

        public void Update(int id, University university)
        {
            var existingUniversity = _universities.FirstOrDefault(u => u.RegistrationNumber == id);
            if (existingUniversity != null)
            {
                existingUniversity.Name = university.Name;
                existingUniversity.Address = university.Address;
                existingUniversity.InstitutionOwnership = university.InstitutionOwnership;
                existingUniversity.BuildingOwnership = university.BuildingOwnership;
            }
        }

        public void Delete(int id)
        {
            var university = _universities.FirstOrDefault(u => u.RegistrationNumber == id);
            if (university != null)
            {
                _universities.Remove(university);
            }
        }

        // Аналитические запросы

        // 1) Вывести информацию о топ 5 университетах с максимальным количеством кафедр
        public List<UniversityDto> GetTopUniversitiesByDepartments()
        {
            return _universities
                .OrderByDescending(u => u.Faculties.SelectMany(f => f.Departments).Count()) // Считаем кафедры по всем факультетам
                .Take(5)
                .Select(u => new UniversityDto
                {
                    RegistrationNumber = u.RegistrationNumber,
                    Name = u.Name,
                    Address = u.Address,
                    InstitutionOwnership = u.InstitutionOwnership,
                    BuildingOwnership = u.BuildingOwnership
                })
                .ToList();
        }

        // 2) Вывести информацию о топ 5 популярных специальностях с максимальным количеством групп
        public List<SpecialtyDto> GetTop5SpecialtiesByGroups()
        {
            return _universities
                .SelectMany(u => u.Faculties.SelectMany(f => f.Departments.SelectMany(d => d.Specialties)))
                .OrderByDescending(s => s.GroupCount)
                .Take(5)
                .Select(s => new SpecialtyDto
                {
                    Name = s.Name,
                    Code = s.Code,
                    GroupCount = s.GroupCount
                })
                .ToList();
        }

        // 3) Вывести информацию о ВУЗах с заданной собственностью учреждения
        public List<UniversityDto> GetUniversitiesByOwnership(string ownership)
        {
            return _universities
                .Where(u => u.InstitutionOwnership.Equals(ownership, StringComparison.OrdinalIgnoreCase))
                .Select(u => new UniversityDto
                {
                    RegistrationNumber = u.RegistrationNumber,
                    Name = u.Name,
                    Address = u.Address,
                    InstitutionOwnership = u.InstitutionOwnership,
                    BuildingOwnership = u.BuildingOwnership
                })
                .ToList();
        }

        // 4) Вывести информацию о количестве факультетов, кафедр и специальностей по каждому типу собственности
        public Dictionary<string, (int faculties, int departments, int specialties)> GetSummaryByOwnership()
        {
            return _universities
                .GroupBy(u => new { u.InstitutionOwnership, u.BuildingOwnership })
                .ToDictionary(
                    g => $"{g.Key.InstitutionOwnership} - {g.Key.BuildingOwnership}",
                    g => (
                        faculties: g.SelectMany(u => u.Faculties).Count(),
                        departments: g.SelectMany(u => u.Faculties.SelectMany(f => f.Departments)).Count(),
                        specialties: g.SelectMany(u => u.Faculties.SelectMany(f => f.Departments.SelectMany(d => d.Specialties))).Count()
                    )
                );
        }

        // 5) Вывести информацию о выбранном вузе
        public UniversityDto? GetUniversityDetails(int id)
        {
            var university = GetById(id);
            if (university == null)
                return null;

            return new UniversityDto
            {
                RegistrationNumber = university.RegistrationNumber,
                Name = university.Name,
                Address = university.Address,
                InstitutionOwnership = university.InstitutionOwnership,
                BuildingOwnership = university.BuildingOwnership
            };
        }
    }
}
