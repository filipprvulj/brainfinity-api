using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Brainfinity.Data.Migrations
{
    public partial class SeedStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[] { new Guid("8f9602ac-a032-4608-9764-96b6e447c43f"), "Aktivno" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[] { new Guid("4933b1c4-9a18-437c-87f3-92f4c11caacf"), "Nadolazeće" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[] { new Guid("c68e06ad-d0d2-49c2-9f7a-a04ea52bcccd"), "Završeno" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4933b1c4-9a18-437c-87f3-92f4c11caacf"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("8f9602ac-a032-4608-9764-96b6e447c43f"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("c68e06ad-d0d2-49c2-9f7a-a04ea52bcccd"));
        }
    }
}
