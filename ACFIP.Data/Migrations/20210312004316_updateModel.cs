using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP.Data.Migrations
{
    public partial class updateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_group_camera_area_area_id",
                table: "group_camera");

            migrationBuilder.AddColumn<string>(
                name: "guard_name",
                table: "violation_case",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "violation_case",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "area_id",
                table: "group_camera",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "account",
                nullable: true);

            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "id", "created_time", "deleted_flag", "hashed_password", "is_active", "role_id", "salt", "email" },
                values: new object[] { "Admin1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "TdavOrKGmKVFNCPb7dkf8xcGHfzaGO4sni/tplKUmg2HTrr8fgzgnXKy43KtTBHRlYlY57NeY2jgfZ3YjDXc3g==", true, 1, new byte[] { 52, 183, 119, 5, 125, 143, 146, 55, 29, 174, 10, 114, 101, 70, 46, 160 }, null });

            migrationBuilder.AddForeignKey(
                name: "FK_group_camera_area_area_id",
                table: "group_camera",
                column: "area_id",
                principalTable: "area",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_group_camera_area_area_id",
                table: "group_camera");

            migrationBuilder.DeleteData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1");

            migrationBuilder.DropColumn(
                name: "guard_name",
                table: "violation_case");

            migrationBuilder.DropColumn(
                name: "status",
                table: "violation_case");

            migrationBuilder.DropColumn(
                name: "email",
                table: "account");

            migrationBuilder.AlterColumn<int>(
                name: "area_id",
                table: "group_camera",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_group_camera_area_area_id",
                table: "group_camera",
                column: "area_id",
                principalTable: "area",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
