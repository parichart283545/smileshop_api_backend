using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_DotNetCoreAPI.Migrations
{
    public partial class fixCreatedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0d3cfa06-312b-4fb9-bc03-d46d5fa944d5"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("16328900-db76-4a0a-a9c8-d086f667aa75"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("d0afe388-d89f-4fe9-af30-b36366811f65"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ef729557-7030-4f7f-a5ce-a19cc155b790"));

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProductGroups");

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("fcb53907-d829-4273-9eeb-5f34b61dab7a"), "user" },
                    { new Guid("2958c31b-d53e-44a8-9809-4132540ee242"), "Manager" },
                    { new Guid("bda1c2d8-248f-4fa8-ada8-64920f54da2b"), "Admin" },
                    { new Guid("ddcac69d-db5b-4d1c-9753-27f0796b80d3"), "Developer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2958c31b-d53e-44a8-9809-4132540ee242"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("bda1c2d8-248f-4fa8-ada8-64920f54da2b"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ddcac69d-db5b-4d1c-9753-27f0796b80d3"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("fcb53907-d829-4273-9eeb-5f34b61dab7a"));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ProductGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("16328900-db76-4a0a-a9c8-d086f667aa75"), "user" },
                    { new Guid("ef729557-7030-4f7f-a5ce-a19cc155b790"), "Manager" },
                    { new Guid("0d3cfa06-312b-4fb9-bc03-d46d5fa944d5"), "Admin" },
                    { new Guid("d0afe388-d89f-4fe9-af30-b36366811f65"), "Developer" }
                });
        }
    }
}
