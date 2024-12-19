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
        builder.Configuration.GetConnectionString("DefaultConnection")!,
        new MySqlServerVersion(new Version(8, 0, 39)),
        b => b.MigrationsAssembly("UniversityData.Domain") // Specify the migrations assembly here
    )
);

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<IRectorRepository, RectorRepository>();
builder.Services.AddScoped<IFacultyRepository, FacultyRepository>();
builder.Services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<ISpecialtyTableNodeRepository, SpecialtyTableNodeRepository>();
builder.Services.AddScoped<IUniversityRepository, UniversityRepository>();

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