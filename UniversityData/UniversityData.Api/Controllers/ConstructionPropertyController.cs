﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityData.Api.Dto;
using UniversityData.Domain;

namespace UniversityData.Api.Controllers;

/// <summary>
/// Контроллер собственности зданий университета
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ConstructionPropertyController : ControllerBase
{
    /// <summary>
    /// Хранение логгера
    /// </summary>
    private readonly ILogger<DepartmentController> _logger;
    /// <summary>
    /// Хранение ContextFactory
    /// </summary>
    private readonly IDbContextFactory<UniversityDataDbContext> _contextFactory;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ConstructionPropertyController"/>.
    /// </summary>
    /// <param name="logger">Логгер для записи информации и ошибок.</param>
    /// <param name="contextFactory">Фабрика контекста базы данных для создания экземпляров <see cref="UniversityDataDbContext"/>.</param>
    /// <param name="mapper">Объект для преобразования между объектами модели и DTO.</param>

    public ConstructionPropertyController(ILogger<DepartmentController> logger, IDbContextFactory<UniversityDataDbContext> contextFactory, IMapper mapper)
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
    public async Task<IEnumerable<ConstructionPropertyGetDto>> Get()
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var constructionProperties = await ctx.ConstructionProperties.ToArrayAsync();
        _logger.LogInformation("Get all construction properties");
        return _mapper.Map<IEnumerable<ConstructionPropertyGetDto>>(constructionProperties);
    }
    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ConstructionPropertyGetDto?>> Get(int id)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var constructionProperty = ctx.ConstructionProperties.FirstOrDefault(constructionProperty => constructionProperty.Id == id);
        if (constructionProperty == null)
        {
            _logger.LogInformation("Not found construction property with id: {0}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get construction property with id: {0}", id);
            return Ok(_mapper.Map<ConstructionPropertyGetDto>(constructionProperty));
        }
    }
    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="constructionProperty"></param>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ConstructionPropertyPostDto constructionProperty)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        ctx.ConstructionProperties.Add(_mapper.Map<ConstructionProperty>(constructionProperty));
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Add new construction property");
        return Ok();
    }
    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="constructionPropertyToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ConstructionPropertyPostDto constructionPropertyToPut)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var constructionProperty = ctx.ConstructionProperties.FirstOrDefault(constructionProperty => constructionProperty.Id == id);
        if (constructionProperty == null)
        {
            _logger.LogInformation("Not found construction property with id: {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map<ConstructionPropertyPostDto, ConstructionProperty>(constructionPropertyToPut, constructionProperty);
            await ctx.SaveChangesAsync();
            _logger.LogInformation("Update construction property with id: {0}", id);
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
        var constructionProperty = ctx.ConstructionProperties.FirstOrDefault(constructionProperty => constructionProperty.Id == id);
        if (constructionProperty == null)
        {
            _logger.LogInformation("Not found construction property with id: {0}", id);
            return NotFound();
        }
        else
        {
            ctx.ConstructionProperties.Remove(constructionProperty);
            await ctx.SaveChangesAsync();
            _logger.LogInformation("Delete construction property with id: {0}", id);
            return Ok();
        }
    }
}