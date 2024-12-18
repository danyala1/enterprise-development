namespace UniversityData.Api.Dto;

public class UniversityStructureDto
{
    public IEnumerable<DepartmentGetDto> Departments { get; set; }
    public IEnumerable<FacultyGetDto> Faculties { get; set; }
    public IEnumerable<SpecialtyTableNodeGetDto> Specialties { get; set; }
}
