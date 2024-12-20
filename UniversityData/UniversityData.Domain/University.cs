namespace UniversityData.Domain
{
    public class University
    {
        public int RegistrationNumber { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required Rector Rector { get; set; }
        public required string InstitutionOwnership { get; set; } // "Муниципальная", "Частная"
        public required string BuildingOwnership { get; set; } // "Федеральная", "Муниципальная", "Частная"
        public List<Faculty> Faculties { get; set; } = new List<Faculty>();
    }
}