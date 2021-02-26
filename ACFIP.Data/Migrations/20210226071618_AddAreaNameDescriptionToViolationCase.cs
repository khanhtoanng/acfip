using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP.Data.Migrations
{
    public partial class AddAreaNameDescriptionToViolationCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "area_description",
                table: "violation_case",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "area_name",
                table: "violation_case",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "area_description",
                table: "violation_case");

            migrationBuilder.DropColumn(
                name: "area_name",
                table: "violation_case");
        }
    }
}
