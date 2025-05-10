using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tansiqy.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                name: "Favourites",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => x.ID);
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
                    Degree_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Degrees_Degree_Id",
                        column: x => x.Degree_Id,
                        principalTable: "Degrees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    faculty_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_faculty_Id",
                        column: x => x.faculty_Id,
                        principalTable: "Faculties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacultyDegrees",
                columns: table => new
                {
                    FID = table.Column<int>(type: "int", nullable: false),
                    DegID = table.Column<int>(type: "int", nullable: false),
                    FacultyID = table.Column<int>(type: "int", nullable: false),
                    DegreeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyDegrees", x => new { x.FID, x.DegID });
                    table.ForeignKey(
                        name: "FK_FacultyDegrees_Degrees_DegreeID",
                        column: x => x.DegreeID,
                        principalTable: "Degrees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyDegrees_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacultyFavourites",
                columns: table => new
                {
                    FID = table.Column<int>(type: "int", nullable: false),
                    FavID = table.Column<int>(type: "int", nullable: false),
                    FacultyID = table.Column<int>(type: "int", nullable: false),
                    FavouriteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyFavourites", x => new { x.FID, x.FavID });
                    table.ForeignKey(
                        name: "FK_FacultyFavourites_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyFavourites_Favourites_FavouriteID",
                        column: x => x.FavouriteID,
                        principalTable: "Favourites",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacultyUniversities",
                columns: table => new
                {
                    FID = table.Column<int>(type: "int", nullable: false),
                    UniID = table.Column<int>(type: "int", nullable: false),
                    FacultyID = table.Column<int>(type: "int", nullable: false),
                    UniversityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyUniversities", x => new { x.FID, x.UniID });
                    table.ForeignKey(
                        name: "FK_FacultyUniversities_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyUniversities_Universities_UniversityID",
                        column: x => x.UniversityID,
                        principalTable: "Universities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DegreeDepartments",
                columns: table => new
                {
                    DegID = table.Column<int>(type: "int", nullable: false),
                    DepID = table.Column<int>(type: "int", nullable: false),
                    DegreeID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeDepartments", x => new { x.DegID, x.DepID });
                    table.ForeignKey(
                        name: "FK_DegreeDepartments_Degrees_DegreeID",
                        column: x => x.DegreeID,
                        principalTable: "Degrees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DegreeDepartments_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniversityDepartments",
                columns: table => new
                {
                    UniID = table.Column<int>(type: "int", nullable: false),
                    DepID = table.Column<int>(type: "int", nullable: false),
                    UniversityID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityDepartments", x => new { x.UniID, x.DepID });
                    table.ForeignKey(
                        name: "FK_UniversityDepartments_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UniversityDepartments_Universities_UniversityID",
                        column: x => x.UniversityID,
                        principalTable: "Universities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DegreeDepartments_DegreeID",
                table: "DegreeDepartments",
                column: "DegreeID");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeDepartments_DepartmentID",
                table: "DegreeDepartments",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_faculty_Id",
                table: "Departments",
                column: "faculty_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyDegrees_DegreeID",
                table: "FacultyDegrees",
                column: "DegreeID");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyDegrees_FacultyID",
                table: "FacultyDegrees",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyFavourites_FacultyID",
                table: "FacultyFavourites",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyFavourites_FavouriteID",
                table: "FacultyFavourites",
                column: "FavouriteID");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyUniversities_FacultyID",
                table: "FacultyUniversities",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyUniversities_UniversityID",
                table: "FacultyUniversities",
                column: "UniversityID");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityDepartments_DepartmentID",
                table: "UniversityDepartments",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityDepartments_UniversityID",
                table: "UniversityDepartments",
                column: "UniversityID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Degree_Id",
                table: "Users",
                column: "Degree_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DegreeDepartments");

            migrationBuilder.DropTable(
                name: "FacultyDegrees");

            migrationBuilder.DropTable(
                name: "FacultyFavourites");

            migrationBuilder.DropTable(
                name: "FacultyUniversities");

            migrationBuilder.DropTable(
                name: "UniversityDepartments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Favourites");

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
