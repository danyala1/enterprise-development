﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityData.Api.Dto;
using UniversityData.Domain;
namespace UniversityData.Api.Controllers;

/// <summary>
/// Контроллер ректора
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RectorController : ControllerBase
{
    /// <summary>
    /// Хранение логгера
    /// </summary>
    private readonly ILogger<RectorController> _logger;
    /// <summary>
    /// Хранение ContextFactory
    /// </summary>
    private readonly IDbContextFactory<UniversityDataDbContext> _contextFactory;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public RectorController(ILogger<RectorController> logger, IDbContextFactory<UniversityDataDbContext> contextFactory, IMapper mapper)
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
    public async Task<IEnumerable<RectorGetDto>> Get()
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var rectors = await ctx.Rectors.ToArrayAsync();
        _logger.LogInformation("Get all rectors");
        return _mapper.Map<IEnumerable<RectorGetDto>>(rectors);
    }
    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<RectorGetDto?>> Get(int id)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();

        var rector = await ctx.Rectors.FirstOrDefaultAsync(r => r.Id == id);
        if (rector == null)
        {
            _logger.LogInformation("Not found rector with id: {0}", id);
            return NotFound();
        }

        _logger.LogInformation("Get rector with id: {0}", id);
        return Ok(_mapper.Map<RectorGetDto>(rector));
    }
    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="rector"></param>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] RectorPostDto rector)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        ctx.Rectors.Add(_mapper.Map<Rector>(rector));
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Add new rector");
        return Ok();

    }
    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="rectorToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] RectorPostDto rectorToPut)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();

        var rector = await ctx.Rectors.FirstOrDefaultAsync(r => r.Id == id);
        if (rector == null)
        {
            _logger.LogInformation($"Not found rector with id: {id}");
            return NotFound();
        }

        _mapper.Map(rectorToPut, rector);
        await ctx.SaveChangesAsync();

        _logger.LogInformation("Updated rector with id: {0}", id);
        return Ok();
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

        var rector = await ctx.Rectors.FirstOrDefaultAsync(r => r.Id == id);
        if (rector == null)
        {
            _logger.LogInformation("Not found rector with id: {0}", id);
            return NotFound();
        }

        ctx.Rectors.Remove(rector);
        await ctx.SaveChangesAsync();

        _logger.LogInformation("Deleted rector with id: {0}", id);
        return Ok();
    }
}