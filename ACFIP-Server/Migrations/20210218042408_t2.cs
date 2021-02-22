using Microsoft.EntityFrameworkCore.Migrations;

namespace ACFIP_Server.Migrations
{
    public partial class t2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "camera_camera_configuration");

            migrationBuilder.AddColumn<int>(
                name: "configuration_id",
                table: "camera",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "connection_string",
                table: "camera",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_camera_configuration_id",
                table: "camera",
                column: "configuration_id");

            migrationBuilder.AddForeignKey(
                name: "FK_camera_camera_configuration_configuration_id",
                table: "camera",
                column: "configuration_id",
                principalTable: "camera_configuration",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_camera_camera_configuration_configuration_id",
                table: "camera");

            migrationBuilder.DropIndex(
                name: "IX_camera_configuration_id",
                table: "camera");

            migrationBuilder.DropColumn(
                name: "configuration_id",
                table: "camera");

            migrationBuilder.DropColumn(
                name: "connection_string",
                table: "camera");

            migrationBuilder.CreateTable(
                name: "camera_camera_configuration",
                columns: table => new
                {
                    camera_id = table.Column<int>(type: "int", nullable: false),
                    configuration_id = table.Column<int>(type: "int", nullable: false),
                    connection_string = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_camera_camera_configuration", x => new { x.camera_id, x.configuration_id });
                    table.ForeignKey(
                        name: "FK_camera_camera_configuration_camera_camera_id",
                        column: x => x.camera_id,
                        principalTable: "camera",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_camera_camera_configuration_camera_configuration_configuration_id",
                        column: x => x.configuration_id,
                        principalTable: "camera_configuration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_camera_camera_configuration_configuration_id",
                table: "camera_camera_configuration",
                column: "configuration_id");
        }
    }
}
