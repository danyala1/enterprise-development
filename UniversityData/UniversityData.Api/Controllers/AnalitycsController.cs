using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityData.Api.Dto;
using UniversityData.Domain;
using UniversityData.Domain.Repository;
namespace UniversityData.Api.Controllers;

/// <summary>
/// Контроллер для заданий-запросов
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly UniversityDataDbContext _dbContext;
    private readonly ILogger<AnalyticsController> _logger;
    private readonly IMapper _mapper;
    private readonly ISpecialtyRepository _specialtyRepository;
    private readonly IUniversityRepository _universityRepository;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="AnalyticsController"/>.
    /// </summary>
    /// <param name="dbContext">Контекст базы данных для доступа к данным.</param>
    /// <param name="logger">Логгер для записи информации и ошибок.</param>
    /// <param name="mapper">Объект для преобразования между объектами модели и DTO.</param>
    /// <param name="specialtyRepository">Репозиторий для работы со специальностями.</param>
    /// <param name="universityRepository">Репозиторий для работы с университетами.</param>

    public AnalyticsController(UniversityDataDbContext dbContext, ILogger<AnalyticsController> logger, IMapper mapper, ISpecialtyRepository specialtyRepository, IUniversityRepository universityRepository)
    {
        _dbContext = dbContext;
        _logger = logger;
        _mapper = mapper;
        _specialtyRepository = specialtyRepository;
        _universityRepository = universityRepository;
    }

    /// <summary>
    /// Запрос 1 - Вывести информацию о выбранном вузе.
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    [HttpGet("information_of_university{number}")]
    public async Task<ActionResult<UniversityGetDto>> GetInformationOfUniversity(string number)
    {
        _logger.LogInformation("Fetching information for university with number: {0}", number);

        // Используем существующий контекст
        var university = await _dbContext.Universities
            .Where(u => u.Number == number)
            .FirstOrDefaultAsync();

        if (university == null)
        {
            _logger.LogInformation("Not found university with number: {0}", number);
            return NotFound();
        }

        var result = _mapper.Map<University, UniversityGetDto>(university);
        return Ok(result);
    }
    /// <summary>
    /// Запрос 2 - Вывести информацию о факультетах, кафедрах и специальностях данного вуза.
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    [HttpGet("information_of_structure_of_university{number}")]
    public async Task<ActionResult<UniversityStructureDto>> InformationOfStructure(string number)
    {
        _logger.LogInformation("Fetching structure information for university with number: {0}", number);

        var university = await _dbContext.Universities
            .Where(u => u.Number == number)
            .Select(u => new UniversityStructureDto
            {
                Departments = _mapper.Map<IEnumerable<DepartmentGetDto>>(u.DepartmentsData),
                Faculties = _mapper.Map<IEnumerable<FacultyGetDto>>(u.FacultiesData),
                Specialties = _mapper.Map<IEnumerable<SpecialtyTableNodeGetDto>>(u.SpecialtyTable),
            })
            .FirstOrDefaultAsync();

        if (university == null)
        {
            _logger.LogInformation("Not found university with number: {0}", number);
            return NotFound();
        }

        _logger.LogInformation("Get information about structure of university");
        return Ok(university);
    }
    /// <summary>
    /// Запрос 3 - Вывести информацию о топ 5 популярных специальностях (с максимальным количеством групп).
    /// </summary>
    /// <returns></returns>
    [HttpGet("top_five_specialties")]
    public async Task<ActionResult<IEnumerable<SpecialtyGetDto>>> GetTopFiveSpecialties()
    {
        _logger.LogInformation("Fetching top five specialties based on the number of groups.");

        var specialties = await _specialtyRepository.GetTopFiveSpecialtiesAsync();

        // Предполагаем, что метод возвращает коллекцию DTO
        return Ok(specialties);
    }
    /// <summary>
    /// Запрос 4 - Вывести информацию о ВУЗах с максимальным количеством кафедр, упорядочить по названию.
    /// </summary>
    /// <returns></returns>
    [HttpGet("university_with_max_departments")]
    public async Task<IEnumerable<UniversityGetDto>> MaxCountDepartments()
    {
        _logger.LogInformation("Get universities with max count departments");

        var universities = await _universityRepository.GetUniversitiesByDepartmentCountAsync();

        return _mapper.Map<IEnumerable<UniversityGetDto>>(universities);
    }
    /// <summary>
    /// Запрос 5 - Вывести информацию о ВУЗах с заданной собственностью учреждения и количество групп в ВУЗе.
    /// </summary>
    /// <param name="universityPropertyId"></param>
    /// <returns></returns>
    [HttpGet("university_with_target_property")]
    public async Task<ActionResult<IEnumerable<UniversityWithPropertyDto>>> UniversityWithProperty(int universityPropertyId)
    {
        _logger.LogInformation("Get information about universities with target property");

        var universities = await _universityRepository.GetUniversitiesByPropertyIdAsync(universityPropertyId);

        // Преобразование результата в нужный DTO
        var result = universities.Select(u => new UniversityWithPropertyDto
        {
            Id = u.Id,
            Name = u.Name,
            Number = u.Number,
            RectorId = u.RectorId,
            ConstructionProperty = u.ConstructionProperty?.ToString() ?? "Not specified",
            UniversityProperty = u.UniversityProperty?.ToString() ?? "Not specified",
            CountGroups = u.SpecialtyTable.Sum(s => s.CountGroups)
        });


        return Ok(result);
    }

    /// <summary>
    /// Запрос 6 - Вывести информацию о количестве факультетов, кафедр, специальностей по каждому типу собственности учреждения и собственности здания.
    /// </summary>
    /// <returns></returns>
    [HttpGet("count_departments")]
    public async Task<ActionResult<IEnumerable<DepartmentCountDto>>> CountDepartments()
    {
        _logger.LogInformation("Get counts of faculties, departments and specialties");

        var result = await (from university in _dbContext.Universities
                            group university by new
                            {
                                UniversityPropertyId = university.UniversityProperty != null ? university.UniversityProperty.Id : 0,
                                university.ConstructionPropertyId
                            } into universityGroup
                            select new DepartmentCountDto
                            {
                                ConstructionPropertyId = universityGroup.Key.ConstructionPropertyId,
                                UniversityPropertyId = universityGroup.Key.UniversityPropertyId,
                                FacultiesCount = universityGroup.Sum(u => u.FacultiesData.Count),
                                DepartmentsCount = universityGroup.Sum(u => u.DepartmentsData.Count),
                                SpecialtiesCount = universityGroup.Sum(u => u.SpecialtyTable.Count)
                            }).ToListAsync();



        return Ok(result);
    }
}