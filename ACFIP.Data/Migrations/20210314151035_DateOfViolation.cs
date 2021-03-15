using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP.Data.Migrations
{
    public partial class DateOfViolation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "time_start",
                table: "guard",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "time_end",
                table: "guard",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<DateTime>(
                name: "date_of_violation",
                table: "area",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "JW57UY8xLnIpmeaPHs269QgKUVIy8IgxZ2ckzibAbASCjWR5FFgC63e9Lu4BV/0U3OXGUhth8RH+2nOFNtsvKA==", new byte[] { 85, 119, 151, 165, 144, 201, 144, 214, 212, 189, 22, 229, 249, 161, 128, 33 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date_of_violation",
                table: "area");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "time_start",
                table: "guard",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "time_end",
                table: "guard",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "SQFBJY2JUWIYq54l+phJbGsPmcF6fLV0h29ubCEERdIbr6NP075JMb+VktPCImaj7gQdp0Jyq0goj+4KwTtNQQ==", new byte[] { 16, 153, 238, 41, 91, 134, 62, 183, 194, 178, 143, 27, 2, 72, 149, 175 } });
        }
    }
}
