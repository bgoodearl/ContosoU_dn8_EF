using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CU.Infrastructure.Migrations
{
    public partial class CU6_M05_AddLookups2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "OBLTId",
                table: "OfficeAssignment",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficeBuildingCode",
                table: "OfficeAssignment",
                type: "nvarchar(2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfficeAssignment_OBLTId_OfficeBuildingCode",
                table: "OfficeAssignment",
                columns: new[] { "OBLTId", "OfficeBuildingCode" });

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeAssignment_xLookups2cKey_OBLTId_OfficeBuildingCode",
                table: "OfficeAssignment",
                columns: new[] { "OBLTId", "OfficeBuildingCode" },
                principalTable: "xLookups2cKey",
                principalColumns: new[] { "LookupTypeId", "Code" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeAssignment_xLookups2cKey_OBLTId_OfficeBuildingCode",
                table: "OfficeAssignment");

            migrationBuilder.DropIndex(
                name: "IX_OfficeAssignment_OBLTId_OfficeBuildingCode",
                table: "OfficeAssignment");

            migrationBuilder.DropColumn(
                name: "OBLTId",
                table: "OfficeAssignment");

            migrationBuilder.DropColumn(
                name: "OfficeBuildingCode",
                table: "OfficeAssignment");
        }
    }
}
