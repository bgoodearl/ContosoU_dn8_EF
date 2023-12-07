using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CU.Infrastructure.Migrations
{
    public partial class CU6_M04_AddLookups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "xLookups2cKey",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    LookupTypeId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    _SubType = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xLookups2cKey", x => new { x.LookupTypeId, x.Code });
                });

            migrationBuilder.CreateTable(
                name: "xLookupTypes",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BaseTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xLookupTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_coursesPresentationTypes",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    LookupTypeId = table.Column<short>(type: "smallint", nullable: false),
                    CoursePresentationTypeCode = table.Column<string>(type: "nvarchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__coursesPresentationTypes", x => new { x.CourseID, x.LookupTypeId, x.CoursePresentationTypeCode });
                    table.ForeignKey(
                        name: "FK__coursesPresentationTypes_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__coursesPresentationTypes_xLookups2cKey_LookupTypeId_CoursePresentationTypeCode",
                        columns: x => new { x.LookupTypeId, x.CoursePresentationTypeCode },
                        principalTable: "xLookups2cKey",
                        principalColumns: new[] { "LookupTypeId", "Code" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_departmentsFacilityTypes",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    LookupTypeId = table.Column<short>(type: "smallint", nullable: false),
                    DepartmentFacilityTypeCode = table.Column<string>(type: "nvarchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__departmentsFacilityTypes", x => new { x.DepartmentID, x.LookupTypeId, x.DepartmentFacilityTypeCode });
                    table.ForeignKey(
                        name: "FK__departmentsFacilityTypes_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__departmentsFacilityTypes_xLookups2cKey_LookupTypeId_DepartmentFacilityTypeCode",
                        columns: x => new { x.LookupTypeId, x.DepartmentFacilityTypeCode },
                        principalTable: "xLookups2cKey",
                        principalColumns: new[] { "LookupTypeId", "Code" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__coursesPresentationTypes_LookupTypeId_CoursePresentationTypeCode",
                table: "_coursesPresentationTypes",
                columns: new[] { "LookupTypeId", "CoursePresentationTypeCode" });

            migrationBuilder.CreateIndex(
                name: "IX__departmentsFacilityTypes_LookupTypeId_DepartmentFacilityTypeCode",
                table: "_departmentsFacilityTypes",
                columns: new[] { "LookupTypeId", "DepartmentFacilityTypeCode" });

            migrationBuilder.CreateIndex(
                name: "LookupTypeAndName",
                table: "xLookups2cKey",
                columns: new[] { "LookupTypeId", "Name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_coursesPresentationTypes");

            migrationBuilder.DropTable(
                name: "_departmentsFacilityTypes");

            migrationBuilder.DropTable(
                name: "xLookupTypes");

            migrationBuilder.DropTable(
                name: "xLookups2cKey");
        }
    }
}
