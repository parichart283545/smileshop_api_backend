using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_DotNetCoreAPI.Migrations
{
    public partial class MovementTypeCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("03314440-e9d3-4e5c-b1b6-f6352749a47f"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0e43c793-b811-4226-8e7e-cbe757fffff3"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("cea17f49-6664-489e-9849-fb67f952c892"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("cf040d30-b34b-4e0d-b9ca-dd8b9129568d"));

            migrationBuilder.CreateTable(
                name: "MovementType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementType", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("218f3aa5-abfb-4092-adec-cc2a37c890ac"), "user" },
                    { new Guid("bd0fbdd7-6e3d-44b4-9d36-55d00541562e"), "Manager" },
                    { new Guid("66291336-d977-469e-8128-07ab5e7f354c"), "Admin" },
                    { new Guid("60d6c98d-c069-4877-867a-37c1d6899840"), "Developer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovementType");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("218f3aa5-abfb-4092-adec-cc2a37c890ac"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("60d6c98d-c069-4877-867a-37c1d6899840"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("66291336-d977-469e-8128-07ab5e7f354c"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("bd0fbdd7-6e3d-44b4-9d36-55d00541562e"));

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("cea17f49-6664-489e-9849-fb67f952c892"), "user" },
                    { new Guid("cf040d30-b34b-4e0d-b9ca-dd8b9129568d"), "Manager" },
                    { new Guid("03314440-e9d3-4e5c-b1b6-f6352749a47f"), "Admin" },
                    { new Guid("0e43c793-b811-4226-8e7e-cbe757fffff3"), "Developer" }
                });
        }
    }
}
