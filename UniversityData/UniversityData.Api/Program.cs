using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniversityData.Domain;
using UniversityData.Domain.Repository;
using UniversityData.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<UniversityDataDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("UniversityData")!)
);

var mapperConfig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
var mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddSingleton<IUniversityDataRepository, UniversityDataRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();