using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP.Data.Migrations
{
    public partial class UpdateRequiredInCamera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_camera_area_area_id",
                table: "camera");

            migrationBuilder.DropForeignKey(
                name: "FK_camera_camera_configuration_configuration_id",
                table: "camera");

            migrationBuilder.AlterColumn<int>(
                name: "configuration_id",
                table: "camera",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "area_id",
                table: "camera",
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

            migrationBuilder.AddForeignKey(
                name: "FK_camera_camera_configuration_configuration_id",
                table: "camera",
                column: "configuration_id",
                principalTable: "camera_configuration",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_camera_area_area_id",
                table: "camera");

            migrationBuilder.DropForeignKey(
                name: "FK_camera_camera_configuration_configuration_id",
                table: "camera");

            migrationBuilder.AlterColumn<int>(
                name: "configuration_id",
                table: "camera",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "area_id",
                table: "camera",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_camera_area_area_id",
                table: "camera",
                column: "area_id",
                principalTable: "area",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_camera_camera_configuration_configuration_id",
                table: "camera",
                column: "configuration_id",
                principalTable: "camera_configuration",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
