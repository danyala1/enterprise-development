using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityData.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UniversityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "construction_property",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_construction_property = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_construction_property", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rector",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    patronymic = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    degree = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    position = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rector", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "specialty",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountGroups = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialty", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "university_property",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_university_property = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_university_property", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "university",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rector_id = table.Column<int>(type: "int", nullable: false),
                    construction_property_id = table.Column<int>(type: "int", nullable: false),
                    university_property_id = table.Column<int>(type: "int", nullable: false),
                    RectorDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_university", x => x.id);
                    table.ForeignKey(
                        name: "FK_university_construction_property_construction_property_id",
                        column: x => x.construction_property_id,
                        principalTable: "construction_property",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_university_rector_RectorDataId",
                        column: x => x.RectorDataId,
                        principalTable: "rector",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_university_rector_rector_id",
                        column: x => x.rector_id,
                        principalTable: "rector",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_university_university_property_university_property_id",
                        column: x => x.university_property_id,
                        principalTable: "university_property",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    supervisor_number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    university_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.id);
                    table.ForeignKey(
                        name: "FK_department_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "faculty",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    workers_count = table.Column<int>(type: "int", nullable: false),
                    students_count = table.Column<int>(type: "int", nullable: false),
                    university_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faculty", x => x.id);
                    table.ForeignKey(
                        name: "FK_faculty_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "specialty_table_node",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    specialty_id = table.Column<int>(type: "int", nullable: false),
                    count_groups = table.Column<int>(type: "int", nullable: false),
                    university_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialty_table_node", x => x.id);
                    table.ForeignKey(
                        name: "FK_specialty_table_node_specialty_specialty_id",
                        column: x => x.specialty_id,
                        principalTable: "specialty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_specialty_table_node_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "construction_property",
                columns: new[] { "id", "name_construction_property" },
                values: new object[,]
                {
                    { 1, "муниципальная" },
                    { 2, "частная" },
                    { 3, "федеральная" }
                });

            migrationBuilder.InsertData(
                table: "rector",
                columns: new[] { "id", "degree", "name", "patronymic", "position", "surname", "title" },
                values: new object[,]
                {
                    { 1, "Доктор экономических наук", "Владимир", "Дмитриевич", "Ректор", "Богатырев", "Профессор" },
                    { 2, "Доктор технических наук", "Дмитрий", "Евгеньевич", "Ректор", "Быков", "Профессор" },
                    { 3, "Кандидат технических наук", "Вадим", "Александрович", "Ректор", "Ружников", "Доцент" }
                });

            migrationBuilder.InsertData(
                table: "specialty",
                columns: new[] { "id", "code", "CountGroups", "name" },
                values: new object[,]
                {
                    { 1, "09.03.03", 0, "Прикладная информатика" },
                    { 2, "09.03.02", 0, "Информационные системы и технологии" },
                    { 3, "09.03.01", 0, "Информатика и вычислительная техника" },
                    { 4, "01.03.02", 0, "Прикладная математика и информатика" },
                    { 5, "10.05.03", 0, "Информационная безопасность автоматизированных систем" }
                });

            migrationBuilder.InsertData(
                table: "university_property",
                columns: new[] { "id", "name_university_property" },
                values: new object[,]
                {
                    { 1, "муниципальная" },
                    { 2, "частная" }
                });

            migrationBuilder.InsertData(
                table: "university",
                columns: new[] { "id", "address", "construction_property_id", "name", "number", "RectorDataId", "rector_id", "university_property_id" },
                values: new object[,]
                {
                    { 1, "Самара", 1, "Самарский университет", "12345", null, 1, 1 },
                    { 2, "Самара", 1, "СамГТУ", "56789", null, 2, 1 },
                    { 3, "Самара", 3, "ПГУТИ", "45678", null, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "department",
                columns: new[] { "id", "name", "supervisor_number", "university_id" },
                values: new object[,]
                {
                    { 1, "ГИиБ", "890918734", 1 },
                    { 2, "Кафедры алгебры и геометрии", "890918735", 2 },
                    { 3, "Кафедра высшей математики", "890918736", 2 },
                    { 4, "Кафедра информационных технологий", "890918737", 3 }
                });

            migrationBuilder.InsertData(
                table: "faculty",
                columns: new[] { "id", "name", "students_count", "university_id", "workers_count" },
                values: new object[,]
                {
                    { 1, "Институт информатики и кибернетики", 110, 1, 16 },
                    { 2, "Институт экономики и управления", 81, 1, 22 },
                    { 3, "Юридический институт", 65, 1, 11 },
                    { 4, "Социально-гумманитарный институт", 200, 2, 30 },
                    { 5, "Институт доп. образования", 62, 2, 22 },
                    { 6, "Институт двигателей и энергетических установок", 70, 3, 16 }
                });

            migrationBuilder.InsertData(
                table: "specialty_table_node",
                columns: new[] { "id", "count_groups", "specialty_id", "university_id" },
                values: new object[,]
                {
                    { 1, 8, 1, 1 },
                    { 2, 17, 1, 2 },
                    { 3, 6, 2, 1 },
                    { 4, 6, 2, 2 },
                    { 5, 9, 3, 2 },
                    { 6, 4, 3, 1 },
                    { 7, 8, 4, 2 },
                    { 8, 8, 4, 3 },
                    { 9, 10, 5, 3 },
                    { 10, 8, 5, 2 },
                    { 11, 8, 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_department_university_id",
                table: "department",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "IX_faculty_university_id",
                table: "faculty",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "IX_specialty_table_node_specialty_id",
                table: "specialty_table_node",
                column: "specialty_id");

            migrationBuilder.CreateIndex(
                name: "IX_specialty_table_node_university_id",
                table: "specialty_table_node",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "IX_university_construction_property_id",
                table: "university",
                column: "construction_property_id");

            migrationBuilder.CreateIndex(
                name: "IX_university_rector_id",
                table: "university",
                column: "rector_id");

            migrationBuilder.CreateIndex(
                name: "IX_university_RectorDataId",
                table: "university",
                column: "RectorDataId");

            migrationBuilder.CreateIndex(
                name: "IX_university_university_property_id",
                table: "university",
                column: "university_property_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "faculty");

            migrationBuilder.DropTable(
                name: "specialty_table_node");

            migrationBuilder.DropTable(
                name: "specialty");

            migrationBuilder.DropTable(
                name: "university");

            migrationBuilder.DropTable(
                name: "construction_property");

            migrationBuilder.DropTable(
                name: "rector");

            migrationBuilder.DropTable(
                name: "university_property");
        }
    }
}
