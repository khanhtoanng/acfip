using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP.Data.Migrations
{
    public partial class addtimeinGuard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "time_end",
                table: "guard",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "time_start",
                table: "guard",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "SQFBJY2JUWIYq54l+phJbGsPmcF6fLV0h29ubCEERdIbr6NP075JMb+VktPCImaj7gQdp0Jyq0goj+4KwTtNQQ==", new byte[] { 16, 153, 238, 41, 91, 134, 62, 183, 194, 178, 143, 27, 2, 72, 149, 175 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "time_end",
                table: "guard");

            migrationBuilder.DropColumn(
                name: "time_start",
                table: "guard");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "IJOC8Dve1kQEIqWKFJboCqR5l2QU1Iw+TKEnwA7ASFl0NRBK2f9bI1bD/xeu5n74x+Lw/2rhRSlo7kuBDzZwfQ==", new byte[] { 232, 103, 149, 245, 98, 118, 74, 69, 185, 2, 44, 148, 43, 215, 148, 192 } });
        }
    }
}
