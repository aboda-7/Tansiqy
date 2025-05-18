using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tansiqy.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Degrees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degrees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Degrees_DegID",
                        column: x => x.DegID,
                        principalTable: "Degrees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_FID",
                        column: x => x.FID,
                        principalTable: "Faculties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacultyDegrees",
                columns: table => new
                {
                    FID = table.Column<int>(type: "int", nullable: false),
                    DegID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyDegrees", x => new { x.FID, x.DegID });
                    table.ForeignKey(
                        name: "FK_FacultyDegrees_Degrees_DegID",
                        column: x => x.DegID,
                        principalTable: "Degrees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyDegrees_Faculties_FID",
                        column: x => x.FID,
                        principalTable: "Faculties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacultyUniversities",
                columns: table => new
                {
                    FID = table.Column<int>(type: "int", nullable: false),
                    UniID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyUniversities", x => new { x.FID, x.UniID });
                    table.ForeignKey(
                        name: "FK_FacultyUniversities_Faculties_FID",
                        column: x => x.FID,
                        principalTable: "Faculties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyUniversities_Universities_UniID",
                        column: x => x.UniID,
                        principalTable: "Universities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DegreeDepartments",
                columns: table => new
                {
                    DegID = table.Column<int>(type: "int", nullable: false),
                    DepID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeDepartments", x => new { x.DegID, x.DepID });
                    table.ForeignKey(
                        name: "FK_DegreeDepartments_Degrees_DegID",
                        column: x => x.DegID,
                        principalTable: "Degrees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DegreeDepartments_Departments_DepID",
                        column: x => x.DepID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniversityDepartments",
                columns: table => new
                {
                    UniID = table.Column<int>(type: "int", nullable: false),
                    DepID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityDepartments", x => new { x.UniID, x.DepID });
                    table.ForeignKey(
                        name: "FK_UniversityDepartments_Departments_DepID",
                        column: x => x.DepID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UniversityDepartments_Universities_UniID",
                        column: x => x.UniID,
                        principalTable: "Universities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DegreeDepartments_DepID",
                table: "DegreeDepartments",
                column: "DepID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FID",
                table: "Departments",
                column: "FID");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyDegrees_DegID",
                table: "FacultyDegrees",
                column: "DegID");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyUniversities_UniID",
                table: "FacultyUniversities",
                column: "UniID");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityDepartments_DepID",
                table: "UniversityDepartments",
                column: "DepID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DegID",
                table: "Users",
                column: "DegID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DegreeDepartments");

            migrationBuilder.DropTable(
                name: "FacultyDegrees");

            migrationBuilder.DropTable(
                name: "FacultyUniversities");

            migrationBuilder.DropTable(
                name: "UniversityDepartments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropTable(
                name: "Degrees");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
