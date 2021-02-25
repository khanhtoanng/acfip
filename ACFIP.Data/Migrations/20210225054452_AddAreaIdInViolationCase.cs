using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP.Data.Migrations
{
    public partial class AddAreaIdInViolationCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "violation_type");

            migrationBuilder.DropColumn(
                name: "last_modified_time",
                table: "violation_case");

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "violation_case",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "violation_case");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "violation_type",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_time",
                table: "violation_case",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
