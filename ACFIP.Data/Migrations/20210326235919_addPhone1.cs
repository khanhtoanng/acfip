using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP.Data.Migrations
{
    public partial class addPhone1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "account",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "u0K1PtBq1r/yjC2ZEg83QNwu+rUv8FC2aKLRiUkXnkFH5I27u5WVpmhw99NyUx5Cg3meQW5SDEK+FyYYyExaDg==", new byte[] { 75, 79, 68, 221, 43, 187, 235, 79, 15, 245, 39, 108, 153, 198, 201, 141 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phone",
                table: "account");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "cXgOti2ntB3P3nXwW1F2/hnpMYu+mL/fsxejTiq4eojVqgnAVsEjdrgmwSgTVXX7ATaEgiecBiOcNikdHxvJlQ==", new byte[] { 249, 128, 203, 228, 130, 123, 178, 237, 25, 219, 180, 123, 114, 236, 253, 108 } });
        }
    }
}
