using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ACFIP_Server.Migrations
{
    public partial class t : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "area",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_modified_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_area", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "camera_configuration",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    height = table.Column<float>(type: "real", nullable: false),
                    angle = table.Column<float>(type: "real", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_modified_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_camera_configuration", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "violation_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_violation_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "camera",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    area_id = table.Column<int>(type: "int", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_modified_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_camera", x => x.id);
                    table.ForeignKey(
                        name: "FK_camera_area_area_id",
                        column: x => x.area_id,
                        principalTable: "area",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hashed_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salt = table.Column<byte[]>(type: "binary(16)", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    deleted_flag = table.Column<bool>(type: "bit", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_modified_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.id);
                    table.ForeignKey(
                        name: "FK_account_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "violation_case",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    camera_id = table.Column<int>(type: "int", nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    video_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_modified_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_violation_case", x => x.id);
                    table.ForeignKey(
                        name: "FK_violation_case_camera_camera_id",
                        column: x => x.camera_id,
                        principalTable: "camera",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "violation_case_violation_type",
                columns: table => new
                {
                    case_id = table.Column<int>(type: "int", nullable: false),
                    type_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_violation_case_violation_type", x => new { x.case_id, x.type_id });
                    table.ForeignKey(
                        name: "FK_violation_case_violation_type_violation_case_case_id",
                        column: x => x.case_id,
                        principalTable: "violation_case",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_violation_case_violation_type_violation_type_type_id",
                        column: x => x.type_id,
                        principalTable: "violation_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Manager" },
                    { 3, "Monitor" }
                });

            migrationBuilder.InsertData(
                table: "violation_type",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Vest" },
                    { 2, "Helmet" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_role_id",
                table: "account",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_camera_area_id",
                table: "camera",
                column: "area_id");

            migrationBuilder.CreateIndex(
                name: "IX_camera_camera_configuration_configuration_id",
                table: "camera_camera_configuration",
                column: "configuration_id");

            migrationBuilder.CreateIndex(
                name: "IX_violation_case_camera_id",
                table: "violation_case",
                column: "camera_id");

            migrationBuilder.CreateIndex(
                name: "IX_violation_case_violation_type_type_id",
                table: "violation_case_violation_type",
                column: "type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "camera_camera_configuration");

            migrationBuilder.DropTable(
                name: "violation_case_violation_type");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "camera_configuration");

            migrationBuilder.DropTable(
                name: "violation_case");

            migrationBuilder.DropTable(
                name: "violation_type");

            migrationBuilder.DropTable(
                name: "camera");

            migrationBuilder.DropTable(
                name: "area");
        }
    }
}
