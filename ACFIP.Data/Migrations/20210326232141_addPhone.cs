using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP.Data.Migrations
{
    public partial class addPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "cXgOti2ntB3P3nXwW1F2/hnpMYu+mL/fsxejTiq4eojVqgnAVsEjdrgmwSgTVXX7ATaEgiecBiOcNikdHxvJlQ==", new byte[] { 249, 128, 203, 228, 130, 123, 178, 237, 25, 219, 180, 123, 114, 236, 253, 108 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "JW57UY8xLnIpmeaPHs269QgKUVIy8IgxZ2ckzibAbASCjWR5FFgC63e9Lu4BV/0U3OXGUhth8RH+2nOFNtsvKA==", new byte[] { 85, 119, 151, 165, 144, 201, 144, 214, 212, 189, 22, 229, 249, 161, 128, 33 } });
        }
    }
}
