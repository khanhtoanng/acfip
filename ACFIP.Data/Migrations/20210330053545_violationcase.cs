using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP.Data.Migrations
{
    public partial class violationcase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_violation_case_location_location_id",
                table: "violation_case");

            migrationBuilder.DropIndex(
                name: "IX_violation_case_location_id",
                table: "violation_case");

            migrationBuilder.DropColumn(
                name: "location_id",
                table: "violation_case");

            migrationBuilder.AddColumn<int>(
                name: "camera_id",
                table: "violation_case",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "is_view",
                table: "violation_case",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "qtb8IAO8A5OSqyGzRwyKDMWNxBTEaGvRoBqzuLhAYo/lpekWLUvlyLtqWnPurgdmlBp58y/YqPEXgZKN9Fi49w==", new byte[] { 38, 100, 35, 238, 127, 157, 210, 186, 166, 111, 187, 225, 38, 75, 237, 21 } });

            migrationBuilder.CreateIndex(
                name: "IX_violation_case_camera_id",
                table: "violation_case",
                column: "camera_id");

            migrationBuilder.AddForeignKey(
                name: "FK_violation_case_camera_camera_id",
                table: "violation_case",
                column: "camera_id",
                principalTable: "camera",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_violation_case_camera_camera_id",
                table: "violation_case");

            migrationBuilder.DropIndex(
                name: "IX_violation_case_camera_id",
                table: "violation_case");

            migrationBuilder.DropColumn(
                name: "camera_id",
                table: "violation_case");

            migrationBuilder.DropColumn(
                name: "is_view",
                table: "violation_case");

            migrationBuilder.AddColumn<int>(
                name: "location_id",
                table: "violation_case",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "u0K1PtBq1r/yjC2ZEg83QNwu+rUv8FC2aKLRiUkXnkFH5I27u5WVpmhw99NyUx5Cg3meQW5SDEK+FyYYyExaDg==", new byte[] { 75, 79, 68, 221, 43, 187, 235, 79, 15, 245, 39, 108, 153, 198, 201, 141 } });

            migrationBuilder.CreateIndex(
                name: "IX_violation_case_location_id",
                table: "violation_case",
                column: "location_id");

            migrationBuilder.AddForeignKey(
                name: "FK_violation_case_location_location_id",
                table: "violation_case",
                column: "location_id",
                principalTable: "location",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
