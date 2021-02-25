using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP.Data.Migrations
{
    public partial class RenameAreaIdInViolationCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "violation_case",
                newName: "area_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "area_id",
                table: "violation_case",
                newName: "AreaId");
        }
    }
}
