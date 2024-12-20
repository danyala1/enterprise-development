namespace Api.Dto
{
    public class SpecialtyDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int GroupCount { get; set; }
        public int DepartmentId { get; set; } // Кафедра, к которой относится специальность
    }
}
