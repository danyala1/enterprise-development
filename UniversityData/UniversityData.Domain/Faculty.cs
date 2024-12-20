namespace UniversityData.Domain
{
    public class Faculty
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
    }
}