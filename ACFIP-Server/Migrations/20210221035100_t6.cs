using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP_Server.Migrations
{
    public partial class t6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "deleted_flag",
                table: "camera",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "deleted_flag",
                table: "area",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deleted_flag",
                table: "camera");

            migrationBuilder.DropColumn(
                name: "deleted_flag",
                table: "area");
        }
    }
}
