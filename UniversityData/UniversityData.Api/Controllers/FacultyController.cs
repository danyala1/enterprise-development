﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityData.Api.Dto;
using UniversityData.Domain;
namespace UniversityData.Api.Controllers;

/// <summary>
/// Контроллер факультета
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FacultyController : ControllerBase
{
    /// <summary>
    /// Хранение логгера
    /// </summary>
    private readonly ILogger<FacultyController> _logger;
    /// <summary>
    /// Хранение ContextFacroty
    /// </summary>
    private readonly IDbContextFactory<UniversityDataDbContext> _contextFactory;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="FacultyController"/>.
    /// </summary>
    /// <param name="logger">Логгер для записи информации и ошибок.</param>
    /// <param name="contextFactory">Фабрика контекста базы данных для создания экземпляров <see cref="UniversityDataDbContext"/>.</param>
    /// <param name="mapper">Объект для преобразования между объектами модели и DTO.</param>

    public FacultyController(ILogger<FacultyController> logger, IDbContextFactory<UniversityDataDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// GET-запрос на получение всех элементов коллекции
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IEnumerable<FacultyGetDto>> Get()
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var faculties = await ctx.Faculties.ToArrayAsync();
        _logger.LogInformation("Get all faculties");
        return _mapper.Map<IEnumerable<FacultyGetDto>>(faculties);
    }
    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<FacultyGetDto?>> Get(int id)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var faculty = ctx.Faculties.FirstOrDefault(faculty => faculty.Id == id);
        if (faculty == null)
        {
            _logger.LogInformation("Not found faculty with id: {0}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get faculty with id {0}", id);
            return Ok(_mapper.Map<FacultyGetDto>(faculty));
        }
    }
    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="faculty"></param>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] FacultyPostDto faculty)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        ctx.Faculties.Add(_mapper.Map<Faculty>(faculty));
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Add new faculty");
        return Ok();
    }
    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="facultyToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] FacultyPostDto facultyToPut)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var faculty = ctx.Faculties.FirstOrDefault(faculty => faculty.Id == id);
        if (faculty == null)
        {
            _logger.LogInformation("Not found faculty with id: {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map<FacultyPostDto, Faculty>(facultyToPut, faculty);
            await ctx.SaveChangesAsync();
            _logger.LogInformation("Update faculty with id: {0}", id);
            return Ok();
        }
    }
    /// <summary>
    /// DELETE-запрос на удаление элемента из коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var faculty = ctx.Faculties.FirstOrDefault(faculty => faculty.Id == id);
        if (faculty == null)
        {
            _logger.LogInformation("Not found faculty with id: {0}", id);
            return NotFound();
        }
        else
        {
            ctx.Faculties.Remove(faculty);
            await ctx.SaveChangesAsync();
            _logger.LogInformation("Delete faculty with id: {0}", id);
            return Ok();
        }
    }
}