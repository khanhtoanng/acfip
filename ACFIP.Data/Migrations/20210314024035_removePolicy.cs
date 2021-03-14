using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP.Data.Migrations
{
    public partial class removePolicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "ciuDIJcA+7TfMDh/W3Xb7gcdFiGs3VdRfsvv+YrEuaFEUazDQo5u3w5KyRChYPsP/g17C3RY+Ueqb5k8ANub4A==", new byte[] { 36, 13, 95, 226, 254, 22, 147, 81, 156, 175, 173, 106, 81, 62, 107, 187 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "number_of_violation",
                table: "policy");

            migrationBuilder.AddColumn<int>(
                name: "number_of_violation_in_day",
                table: "policy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "number_of_violation_in_month",
                table: "policy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "number_of_violation_in_year",
                table: "policy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "MaPjBbDKcTdvHy4guh5HP4EW3xTQVQ44RwSW9NsPLYDpaMwJ21wTAIwyQ/KnkuUZOZrgVK0i6f+aDjSsm0qbzQ==", new byte[] { 173, 143, 4, 115, 220, 112, 211, 219, 43, 134, 157, 27, 157, 24, 21, 49 } });
        }
    }
}
