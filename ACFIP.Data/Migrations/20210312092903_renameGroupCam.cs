using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP.Data.Migrations
{
    public partial class renameGroupCam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_camera_group_camera_group_id",
                table: "camera");

            migrationBuilder.DropForeignKey(
                name: "FK_violation_case_group_camera_group_id",
                table: "violation_case");

            migrationBuilder.DropTable(
                name: "group_camera");

            migrationBuilder.DropIndex(
                name: "IX_violation_case_group_id",
                table: "violation_case");

            migrationBuilder.DropIndex(
                name: "IX_camera_group_id",
                table: "camera");

            migrationBuilder.DropColumn(
                name: "group_id",
                table: "violation_case");

            migrationBuilder.DropColumn(
                name: "group_id",
                table: "camera");

            migrationBuilder.AddColumn<int>(
                name: "location_id",
                table: "violation_case",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "location_id",
                table: "camera",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: true),
                    deleted_flag = table.Column<bool>(nullable: false),
                    area_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.id);
                    table.ForeignKey(
                        name: "FK_location_area_area_id",
                        column: x => x.area_id,
                        principalTable: "area",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "/nZo/PCK2DhC9tNpEBz0jIp5OimDPYDBOXYo438Ae/dZ+4tQknVbh5wIRrCjlG1LjSIC4XVgk2oxs1DQB6jzbw==", new byte[] { 83, 95, 167, 214, 146, 58, 186, 151, 53, 237, 232, 57, 233, 166, 239, 21 } });

            migrationBuilder.CreateIndex(
                name: "IX_violation_case_location_id",
                table: "violation_case",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_camera_location_id",
                table: "camera",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_location_area_id",
                table: "location",
                column: "area_id");

            migrationBuilder.AddForeignKey(
                name: "FK_camera_location_location_id",
                table: "camera",
                column: "location_id",
                principalTable: "location",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_violation_case_location_location_id",
                table: "violation_case",
                column: "location_id",
                principalTable: "location",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_camera_location_location_id",
                table: "camera");

            migrationBuilder.DropForeignKey(
                name: "FK_violation_case_location_location_id",
                table: "violation_case");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropIndex(
                name: "IX_violation_case_location_id",
                table: "violation_case");

            migrationBuilder.DropIndex(
                name: "IX_camera_location_id",
                table: "camera");

            migrationBuilder.DropColumn(
                name: "location_id",
                table: "violation_case");

            migrationBuilder.DropColumn(
                name: "location_id",
                table: "camera");

            migrationBuilder.AddColumn<int>(
                name: "group_id",
                table: "violation_case",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "group_id",
                table: "camera",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "group_camera",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    area_id = table.Column<int>(type: "int", nullable: true),
                    deleted_flag = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_camera", x => x.id);
                    table.ForeignKey(
                        name: "FK_group_camera_area_area_id",
                        column: x => x.area_id,
                        principalTable: "area",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "rCxHB0X4qSfqQvOSoOFdDYG+lAja60erll5f6XbQS6uj+JvC1RjiG/GmrBuIiZQ9f4ysehn4kGgu+7XLasNL7w==", new byte[] { 68, 19, 139, 238, 196, 132, 63, 113, 147, 243, 218, 157, 239, 130, 197, 233 } });

            migrationBuilder.CreateIndex(
                name: "IX_violation_case_group_id",
                table: "violation_case",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_camera_group_id",
                table: "camera",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_camera_area_id",
                table: "group_camera",
                column: "area_id");

            migrationBuilder.AddForeignKey(
                name: "FK_camera_group_camera_group_id",
                table: "camera",
                column: "group_id",
                principalTable: "group_camera",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_violation_case_group_camera_group_id",
                table: "violation_case",
                column: "group_id",
                principalTable: "group_camera",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
