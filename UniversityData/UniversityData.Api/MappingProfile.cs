using AutoMapper;
using UniversityData.Domain;
using UniversityData.Api.Dto;

namespace UniversityData.Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DepartmentPostDto, Department>().ReverseMap();
        CreateMap<Department, DepartmentGetDto>().ReverseMap();
        CreateMap<FacultyPostDto, Faculty>().ReverseMap();
        CreateMap<Faculty, FacultyGetDto>().ReverseMap();
        CreateMap<RectorPostDto, Rector>().ReverseMap();
        CreateMap<Rector, RectorGetDto>().ReverseMap();
        CreateMap<SpecialtyPostDto, Specialty>().ReverseMap();
        CreateMap<Specialty, SpecialtyGetDto>().ReverseMap();
        CreateMap<UniversityPostDto, University>().ReverseMap();
        CreateMap<University, UniversityGetDto>().ReverseMap();
        CreateMap<SpecialtyTableNodePostDto, SpecialtyTableNode>().ReverseMap();
        CreateMap<SpecialtyTableNode, SpecialtyTableNodeGetDto>().ReverseMap();
        CreateMap<University, UniversityGetStructureDto>().ReverseMap();
        CreateMap<UniversityPropertyPostDto, UniversityProperty>().ReverseMap();
        CreateMap<UniversityProperty, UniversityPropertyGetDto>().ReverseMap();
        CreateMap<ConstructionPropertyPostDto, ConstructionProperty>().ReverseMap();
        CreateMap<ConstructionProperty, ConstructionPropertyGetDto>().ReverseMap();
    }
}