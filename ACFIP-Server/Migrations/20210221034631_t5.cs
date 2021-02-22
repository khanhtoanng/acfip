using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP_Server.Migrations
{
    public partial class t5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_camera_area_area_id",
                table: "camera");

            migrationBuilder.AlterColumn<int>(
                name: "area_id",
                table: "camera",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_camera_area_area_id",
                table: "camera",
                column: "area_id",
                principalTable: "area",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_camera_area_area_id",
                table: "camera");

            migrationBuilder.AlterColumn<int>(
                name: "area_id",
                table: "camera",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_camera_area_area_id",
                table: "camera",
                column: "area_id",
                principalTable: "area",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
