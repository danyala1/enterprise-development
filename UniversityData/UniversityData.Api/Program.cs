using Microsoft.EntityFrameworkCore;
using UniversityData.Api.Services;
using UniversityData.Api;
using UniversityData.Api.Services.Interfaces;
using UniversityData.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClient", policy =>
    {
        var clientAddr = builder.Configuration.GetSection("Client").Get<Dictionary<string, string>>();
        if (clientAddr == null || !clientAddr.Any())
        {
            throw new Exception("Error!");
        }
        policy.WithOrigins(clientAddr.Values.ToArray())
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddDbContext<UniversityDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Postgre"),
        b => b.MigrationsAssembly("UniversityData.Domain")));

builder.Services.AddScoped<IEntityService<Department>, DepartmentService>();
builder.Services.AddScoped<IEntityService<Faculty>, FacultyService>();
builder.Services.AddScoped<IEntityService<Rector>, RectorService>();
builder.Services.AddScoped<IUniversityService, UniversityService>();
builder.Services.AddScoped<ISpecialtyService, SpecialtyService>();
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();

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

app.UseCors("AllowClient");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
