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
    /// <summary>
    /// Хранение логгера
    /// </summary>
    private readonly ILogger<AnalyticsController> _logger;

    private readonly IUniversityRepository _universityRepository;
    /// <summary>
    /// Хранение ContextFactory
    /// </summary>
    private readonly IDbContextFactory<UniversityDataDbContext> _contextFactory;

    private readonly ISpecialtyTableNodeRepository _specialtyTableNodeRepository;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public AnalyticsController(
            ILogger<AnalyticsController> logger,
            IUniversityRepository universityRepository,
            ISpecialtyTableNodeRepository specialtyTableNodeRepository,
            IMapper mapper)
    {
        _logger = logger;
        _universityRepository = universityRepository;
        _specialtyTableNodeRepository = specialtyTableNodeRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Запрос 1 - Вывести информацию о выбранном вузе.
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    [HttpGet("information_of_university{number}")]
    public async Task<ActionResult<UniversityGetDto>> GetInformationOfUniversity(string number)
    {
        var university = await _universityRepository.GetByNumberAsync(number);
        if (university == null)
        {
            _logger.LogInformation("Not found university with number: {0}", number);
            return NotFound();
        }

        _logger.LogInformation("Get information about university");
        return Ok(_mapper.Map<UniversityGetDto>(university));
    }
    /// <summary>
    /// Запрос 2 - Вывести информацию о факультетах, кафедрах и специальностях данного вуза.
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    [HttpGet("information_of_structure_of_university{number}")]
    public async Task<ActionResult<object>> InformationOfStructure(string number)
    {
        var university = await _universityRepository.GetByNumberAsync(number);
        if (university == null)
        {
            _logger.LogInformation("Not found university with number: {0}", number);
            return NotFound();
        }

        var result = new
        {
            departments = _mapper.Map<IEnumerable<DepartmentGetDto>>(university.DepartmentsData),
            faculties = _mapper.Map<IEnumerable<FacultyGetDto>>(university.FacultiesData),
            specialties = _mapper.Map<IEnumerable<SpecialtyTableNodeGetDto>>(university.SpecialtyTable),
        };

        _logger.LogInformation("Get information about structure of university");
        return Ok(result);
    }

    /// <summary>
    /// Запрос 3 - Вывести информацию о топ 5 популярных специальностях (с максимальным количеством групп).
    /// </summary>
    /// <returns></returns>
    [HttpGet("top_five_specialties")]
    public async Task<ActionResult<IEnumerable<object>>> InformationOfTopFiveSpecialties()
    {
        var specialties = await _specialtyTableNodeRepository.GetTopFiveSpecialtiesAsync();

        // Преобразование списка специальностей в нужный формат
        var result = specialties.Select(s => new
        {
            Specialty = s.Specialty.Name,
            CountGroups = s.CountGroups
        });

        _logger.LogInformation("Get top five specialties");
        return Ok(result.Take(5));
    }
    /// <summary>
    /// Запрос 4 - Вывести информацию о ВУЗах с максимальным количеством кафедр, упорядочить по названию.
    /// </summary>
    /// <returns></returns>
    [HttpGet("university_with_max_departments")]
    public async Task<ActionResult<IEnumerable<UniversityGetDto>>> MaxCountDepartments()
    {
        var universities = await _universityRepository.GetUniversitiesWithMaxDepartmentsAsync();

        _logger.LogInformation("Get universities with max count departments");
        return Ok(_mapper.Map<IEnumerable<UniversityGetDto>>(universities));
    }
    /// <summary>
    /// Запрос 5 - Вывести информацию о ВУЗах с заданной собственностью учреждения, и количество групп в ВУЗе.
    /// </summary>
    /// <param name="universityPropertyId"></param>
    /// <returns></returns>
    [HttpGet("university_with_target_property")]
    public async Task<ActionResult<IEnumerable<object>>> UniversityWithProperty(int universityPropertyId)
    {
        var universities = await _universityRepository.GetUniversitiesWithPropertyAsync(universityPropertyId);

        var result = universities.Select(u => new
        {
            u.Id,
            u.Name,
            u.Number,
            u.RectorId,
            u.ConstructionProperty,
            u.UniversityProperty,
            CountGroups = u.SpecialtyTable.Sum(s => s.CountGroups)
        });

        _logger.LogInformation("Get information about universities with target property");
        return Ok(result);
    }
    /// <summary>
    /// Запрос 6 - Вывести информацию о количестве факультетов, кафедр, специальностей по каждому типу собственности учреждения и собственности здания.
    /// </summary>
    /// <returns></returns>
    [HttpGet("count_departments")]
    public async Task<IEnumerable<object>> CountDepartments()
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get counts of faculty, departments and specialties");
        return await (from university in ctx.Universities
                      group university by new { university.UniversityProperty.Id, university.ConstructionPropertyId } into universityConstGroup
                      select new
                      {
                          ConstProp = universityConstGroup.Key.ConstructionPropertyId,
                          UniversityProp = universityConstGroup.Key.Id,
                          Faculties = universityConstGroup.Sum(university => university.FacultiesData.Count),
                          Departments = universityConstGroup.Sum(university => university.DepartmentsData.Count),
                          Specialities = universityConstGroup.Sum(university => university.SpecialtyTable.Count)
                      }).ToListAsync();
    }
}