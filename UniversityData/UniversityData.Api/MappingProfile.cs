using AutoMapper;
using UniversityData.Domain;
using UniversityData.Api.Dto;

namespace UniversityData.Api;

/// <summary>
/// Профиль маппинга для преобразования между объектами модели и DTO.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="MappingProfile"/>.
    /// </summary>
    public MappingProfile()
    {
        // Маппинг для кафедр
        CreateMap<DepartmentPostDto, Department>().ReverseMap();
        CreateMap<Department, DepartmentGetDto>().ReverseMap();

        // Маппинг для факультетов
        CreateMap<FacultyPostDto, Faculty>().ReverseMap();
        CreateMap<Faculty, FacultyGetDto>().ReverseMap();

        // Маппинг для ректоров
        CreateMap<RectorPostDto, Rector>().ReverseMap();
        CreateMap<Rector, RectorGetDto>().ReverseMap();

        // Маппинг для специальностей
        CreateMap<SpecialtyPostDto, Specialty>().ReverseMap();
        CreateMap<Specialty, SpecialtyGetDto>().ReverseMap();

        // Маппинг для университетов
        CreateMap<UniversityPostDto, University>().ReverseMap();
        CreateMap<University, UniversityGetDto>().ReverseMap();

        // Маппинг для узлов специальностей
        CreateMap<SpecialtyTableNodePostDto, SpecialtyTableNode>().ReverseMap();
        CreateMap<SpecialtyTableNode, SpecialtyTableNodeGetDto>().ReverseMap();

        // Маппинг для свойств университета
        CreateMap<UniversityPropertyPostDto, UniversityProperty>().ReverseMap();
        CreateMap<UniversityProperty, UniversityPropertyGetDto>().ReverseMap();

        // Маппинг для строительных свойств
        CreateMap<ConstructionPropertyPostDto, ConstructionProperty>().ReverseMap();
        CreateMap<ConstructionProperty, ConstructionPropertyGetDto>().ReverseMap();
    }
}