using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP.Data.Migrations
{
    public partial class removetimeinGuard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "time_end",
                table: "guard",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "time_start",
                table: "guard",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "ciuDIJcA+7TfMDh/W3Xb7gcdFiGs3VdRfsvv+YrEuaFEUazDQo5u3w5KyRChYPsP/g17C3RY+Ueqb5k8ANub4A==", new byte[] { 36, 13, 95, 226, 254, 22, 147, 81, 156, 175, 173, 106, 81, 62, 107, 187 } });
        }
    }
}
