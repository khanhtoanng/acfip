using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP.Data.Migrations
{
    public partial class updateModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "guard",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    area_id = table.Column<int>(nullable: false),
                    fullname = table.Column<int>(nullable: false),
                    time_start = table.Column<TimeSpan>(nullable: false),
                    time_end = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guard", x => x.id);
                    table.ForeignKey(
                        name: "FK_guard_area_area_id",
                        column: x => x.area_id,
                        principalTable: "area",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "policy",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number_of_violation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_policy", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "8nDX2MFZtW8oCZozAhWVZNkOa1Wld1vYA5TeSUOe/0jBNv/oi47nP3P9J3TTvBWBLT1riAt0GwGtm5+vXIGpsQ==", new byte[] { 3, 138, 227, 147, 107, 157, 69, 85, 110, 185, 122, 116, 172, 213, 194, 4 } });

            migrationBuilder.CreateIndex(
                name: "IX_guard_area_id",
                table: "guard",
                column: "area_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guard");

            migrationBuilder.DropTable(
                name: "policy");

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: "Admin1",
                columns: new[] { "hashed_password", "salt" },
                values: new object[] { "TdavOrKGmKVFNCPb7dkf8xcGHfzaGO4sni/tplKUmg2HTrr8fgzgnXKy43KtTBHRlYlY57NeY2jgfZ3YjDXc3g==", new byte[] { 52, 183, 119, 5, 125, 143, 146, 55, 29, 174, 10, 114, 101, 70, 46, 160 } });
        }
    }
}
