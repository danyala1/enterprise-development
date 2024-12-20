namespace Api.Dto
{
    public class UniversityDto
    {
        public int RegistrationNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string InstitutionOwnership { get; set; }
        public string BuildingOwnership { get; set; }
        public RectorDto Rector { get; set; } // Вложенный объект RectorDto
        public List<FacultyDto> Faculties { get; set; } = new List<FacultyDto>(); // Вложенные объекты Faculties
    }
}
