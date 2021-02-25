using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP.Data.Migrations
{
    public partial class AddManufactureIdInCam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "area_id",
                table: "violation_case");

            migrationBuilder.DropColumn(
                name: "last_modified_time",
                table: "account");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Manager");

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "name" },
                values: new object[] { 3, "Monitor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "area_id",
                table: "violation_case",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_time",
                table: "account",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Manager");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Monitor");
        }
    }
}
