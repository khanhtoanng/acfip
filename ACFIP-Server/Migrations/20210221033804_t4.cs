using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP_Server.Migrations
{
    public partial class t4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "camera",
                newName: "is_active");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "camera",
                newName: "status");
        }
    }
}
