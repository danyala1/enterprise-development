using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniversityData.Domain;
using UniversityData.Domain.Repository;
using UniversityData.Api;

var builder = WebApplication.CreateBuilder(args);

var mapperConfig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
var mapper = mapperConfig.CreateMapper();

builder.Services.AddDbContextFactory<UniversityDataDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("UniversityData")!,
        new MySqlServerVersion(new Version(8, 0, 39))
    )
);

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSingleton(mapper);
builder.Services.AddSingleton<IRectorRepository, RectorRepository>();
builder.Services.AddSingleton<IFacultyRepository, FacultyRepository>();
builder.Services.AddSingleton<ISpecialtyRepository, SpecialtyRepository>();
builder.Services.AddSingleton<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddSingleton<ISpecialtyTableNodeRepository, SpecialtyTableNodeRepository>();
builder.Services.AddSingleton<IUniversityRepository, UniversityRepository>();

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