namespace UniversityData.Api.Dto;
    /// <summary>
    /// Представляет информацию о количестве факультетов, кафедр и специальностей для заданной собственности университета.
    /// </summary>
    public class DepartmentCountDto
    {
        /// <summary>
        /// Идентификатор строительной собственности.
        /// </summary>
        public int ConstructionPropertyId { get; set; }

        /// <summary>
        /// Идентификатор собственности университета.
        /// </summary>
        public int UniversityPropertyId { get; set; }

        /// <summary>
        /// Количество факультетов в университете.
        /// </summary>
        public int FacultiesCount { get; set; }

        /// <summary>
        /// Количество кафедр в университете.
        /// </summary>
        public int DepartmentsCount { get; set; }

        /// <summary>
        /// Количество специальностей в университете.
        /// </summary>
        public int SpecialtiesCount { get; set; }
    }

