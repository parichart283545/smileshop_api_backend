using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_DotNetCoreAPI.Migrations
{
    public partial class MovementTypeCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2f69d7e3-713e-409b-8ae2-e468642512be"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3eeed86b-e7cb-4469-8712-1ccadba510bb"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("94e6eaeb-f4b1-4510-bd01-825a693d8149"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b3e5b1e4-d6ea-4b10-b164-e82e211bf09b"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2f69d7e3-713e-409b-8ae2-e468642512be"), "user" },
                    { new Guid("b3e5b1e4-d6ea-4b10-b164-e82e211bf09b"), "Manager" },
                    { new Guid("94e6eaeb-f4b1-4510-bd01-825a693d8149"), "Admin" },
                    { new Guid("3eeed86b-e7cb-4469-8712-1ccadba510bb"), "Developer" }
                });
        }
    }
}
