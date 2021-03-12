using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP.Data.Migrations
{
    public partial class updateModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "fullname",
                table: "guard",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "rCxHB0X4qSfqQvOSoOFdDYG+lAja60erll5f6XbQS6uj+JvC1RjiG/GmrBuIiZQ9f4ysehn4kGgu+7XLasNL7w==", new byte[] { 68, 19, 139, 238, 196, 132, 63, 113, 147, 243, 218, 157, 239, 130, 197, 233 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "fullname",
                table: "guard",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "8nDX2MFZtW8oCZozAhWVZNkOa1Wld1vYA5TeSUOe/0jBNv/oi47nP3P9J3TTvBWBLT1riAt0GwGtm5+vXIGpsQ==", new byte[] { 3, 138, 227, 147, 107, 157, 69, 85, 110, 185, 122, 116, 172, 213, 194, 4 } });
        }
    }
}
