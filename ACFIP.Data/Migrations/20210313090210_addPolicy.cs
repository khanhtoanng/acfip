using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP.Data.Migrations
{
    public partial class addPolicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "number_of_violation",
                table: "policy");

            migrationBuilder.AddColumn<int>(
                name: "number_of_violation_in_day",
                table: "policy",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "number_of_violation_in_month",
                table: "policy",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "number_of_violation_in_year",
                table: "policy",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "MaPjBbDKcTdvHy4guh5HP4EW3xTQVQ44RwSW9NsPLYDpaMwJ21wTAIwyQ/KnkuUZOZrgVK0i6f+aDjSsm0qbzQ==", new byte[] { 173, 143, 4, 115, 220, 112, 211, 219, 43, 134, 157, 27, 157, 24, 21, 49 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "number_of_violation_in_day",
                table: "policy");

            migrationBuilder.DropColumn(
                name: "number_of_violation_in_month",
                table: "policy");

            migrationBuilder.DropColumn(
                name: "number_of_violation_in_year",
                table: "policy");

            migrationBuilder.AddColumn<int>(
                name: "number_of_violation",
                table: "policy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "/nZo/PCK2DhC9tNpEBz0jIp5OimDPYDBOXYo438Ae/dZ+4tQknVbh5wIRrCjlG1LjSIC4XVgk2oxs1DQB6jzbw==", new byte[] { 83, 95, 167, 214, 146, 58, 186, 151, 53, 237, 232, 57, 233, 166, 239, 21 } });
        }
    }
}
