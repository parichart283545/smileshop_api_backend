using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_DotNetCoreAPI.Migrations
{
    public partial class MovementStockCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("09efc69e-006b-4594-94f9-ce917f9aaf59"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("283637be-e58e-4870-a612-352b67cd62bd"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("5074ef47-b650-4173-99b7-42ad5d4e84df"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("58b2b6f8-f84a-48c1-b254-191987e6833a"));

            migrationBuilder.CreateTable(
                name: "MovementStock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockId = table.Column<int>(nullable: false),
                    MovementTypeId = table.Column<int>(nullable: false),
                    LotId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CreateById = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementStock", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("eef5820e-c49f-4244-80e8-ed0a96654664"), "user" },
                    { new Guid("038a635d-f9e1-4ebb-ad60-07c53d3d5245"), "Manager" },
                    { new Guid("8da6c8c3-f34b-40aa-8399-da6bb56ca9a4"), "Admin" },
                    { new Guid("a3538679-97d2-48f5-a61b-b8bc2d8ff14d"), "Developer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovementStock");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("038a635d-f9e1-4ebb-ad60-07c53d3d5245"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8da6c8c3-f34b-40aa-8399-da6bb56ca9a4"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a3538679-97d2-48f5-a61b-b8bc2d8ff14d"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("eef5820e-c49f-4244-80e8-ed0a96654664"));

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("283637be-e58e-4870-a612-352b67cd62bd"), "user" },
                    { new Guid("5074ef47-b650-4173-99b7-42ad5d4e84df"), "Manager" },
                    { new Guid("58b2b6f8-f84a-48c1-b254-191987e6833a"), "Admin" },
                    { new Guid("09efc69e-006b-4594-94f9-ce917f9aaf59"), "Developer" }
                });
        }
    }
}
