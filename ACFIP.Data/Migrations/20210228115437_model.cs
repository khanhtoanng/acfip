using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP.Data.Migrations
{
    public partial class model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_camera_area_area_id",
                table: "camera");

            migrationBuilder.DropForeignKey(
                name: "FK_violation_case_camera_camera_id",
                table: "violation_case");

            migrationBuilder.DropIndex(
                name: "IX_violation_case_camera_id",
                table: "violation_case");

            migrationBuilder.DropIndex(
                name: "IX_camera_area_id",
                table: "camera");

            migrationBuilder.DropColumn(
                name: "area_description",
                table: "violation_case");

            migrationBuilder.DropColumn(
                name: "area_name",
                table: "violation_case");

            migrationBuilder.DropColumn(
                name: "camera_id",
                table: "violation_case");

            migrationBuilder.DropColumn(
                name: "last_modified_time",
                table: "camera_configuration");

            migrationBuilder.DropColumn(
                name: "area_id",
                table: "camera");

            migrationBuilder.DropColumn(
                name: "last_modified_time",
                table: "camera");

            migrationBuilder.DropColumn(
                name: "manufacture_id",
                table: "camera");

            migrationBuilder.DropColumn(
                name: "last_modified_time",
                table: "area");

            migrationBuilder.AddColumn<int>(
                name: "group_id",
                table: "violation_case",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "group_id",
                table: "camera",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "group_camera",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: true),
                    deleted_flag = table.Column<bool>(nullable: false),
                    area_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_camera", x => x.id);
                    table.ForeignKey(
                        name: "FK_group_camera_area_area_id",
                        column: x => x.area_id,
                        principalTable: "area",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "area_description",
                table: "violation_case",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "area_name",
                table: "violation_case",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "camera_id",
                table: "violation_case",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_time",
                table: "camera_configuration",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "area_id",
                table: "camera",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_time",
                table: "camera",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "manufacture_id",
                table: "camera",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_time",
                table: "area",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_violation_case_camera_id",
                table: "violation_case",
                column: "camera_id");

            migrationBuilder.CreateIndex(
                name: "IX_camera_area_id",
                table: "camera",
                column: "area_id");

            migrationBuilder.AddForeignKey(
                name: "FK_camera_area_area_id",
                table: "camera",
                column: "area_id",
                principalTable: "area",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_violation_case_camera_camera_id",
                table: "violation_case",
                column: "camera_id",
                principalTable: "camera",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
