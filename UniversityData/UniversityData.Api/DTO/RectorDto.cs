namespace Api.Dto
{
    public class RectorDto
    {
        public string FullName { get; set; }
        public string Degree { get; set; }
        public string Title { get; set; }
        public string Position { get; set; }
        public int UniversityId { get; set; } // ВУЗ, к которому относится ректор
    }
}
