using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP.Data.Migrations
{
    public partial class filenameViolation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "file_name",
                table: "violation_case",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "49JGuFxSp3/76V8i56Wrd6mai9PnFugGWvSV8MvWCMawrEkwooYrApn2NaQKuRZtOosfemHHFowIgQza5NNmwA==", new byte[] { 123, 51, 103, 81, 24, 167, 28, 136, 191, 254, 133, 116, 204, 240, 137, 124 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "file_name",
                table: "violation_case");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "qtb8IAO8A5OSqyGzRwyKDMWNxBTEaGvRoBqzuLhAYo/lpekWLUvlyLtqWnPurgdmlBp58y/YqPEXgZKN9Fi49w==", new byte[] { 38, 100, 35, 238, 127, 157, 210, 186, 166, 111, 187, 225, 38, 75, 237, 21 } });
        }
    }
}
