using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted_flag = table.Column<bool>(type: "bit", nullable: false)
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
                    angle = table.Column<float>(type: "real", nullable: false)
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
                name: "group_camera",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    area_id = table.Column<int>(type: "int", nullable: false),
                    deleted_flag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_camera", x => x.group_id);
                    table.ForeignKey(
                        name: "FK_group_camera_area_area_id",
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
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    deleted_flag = table.Column<bool>(type: "bit", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "camera",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    group_id = table.Column<int>(type: "int", nullable: true),
                    connection_string = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    configuration_id = table.Column<int>(type: "int", nullable: false),
                    deleted_flag = table.Column<bool>(type: "bit", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_camera", x => x.id);
                    table.ForeignKey(
                        name: "FK_camera_camera_configuration_configuration_id",
                        column: x => x.configuration_id,
                        principalTable: "camera_configuration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_camera_group_camera_group_id",
                        column: x => x.group_id,
                        principalTable: "group_camera",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "violation_case",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    group_cam_id = table.Column<int>(type: "int", nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    video_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_violation_case", x => x.id);
                    table.ForeignKey(
                        name: "FK_violation_case_group_camera_group_cam_id",
                        column: x => x.group_cam_id,
                        principalTable: "group_camera",
                        principalColumn: "group_id",
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

            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "id", "created_time", "deleted_flag", "hashed_password", "is_active", "role_id", "salt" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "yntcko9S08SPcAriNcWPPlFDEuRD92F82IbcGNqj9duPFxX4P36TR/OtoHgP0oHtsvAxIeV/7FRS4c025LfhKw==", true, 1, new byte[] { 72, 74, 29, 133, 5, 228, 63, 114, 149, 56, 6, 17, 4, 251, 12, 105 } });

            migrationBuilder.CreateIndex(
                name: "IX_account_role_id",
                table: "account",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_camera_configuration_id",
                table: "camera",
                column: "configuration_id");

            migrationBuilder.CreateIndex(
                name: "IX_camera_group_id",
                table: "camera",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_camera_area_id",
                table: "group_camera",
                column: "area_id");

            migrationBuilder.CreateIndex(
                name: "IX_violation_case_group_cam_id",
                table: "violation_case",
                column: "group_cam_id");

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
                name: "camera");

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
                name: "group_camera");

            migrationBuilder.DropTable(
                name: "area");
        }
    }
}
