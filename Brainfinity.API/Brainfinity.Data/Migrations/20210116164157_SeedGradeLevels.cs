using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Brainfinity.Data.Migrations
{
    public partial class SeedGradeLevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GradeLevels",
                columns: new[] { "Id", "GradeLevelName" },
                values: new object[] { new Guid("9b46dc05-75f8-49d8-a09d-19894e0c76a4"), "Osnovna škola" });

            migrationBuilder.InsertData(
                table: "GradeLevels",
                columns: new[] { "Id", "GradeLevelName" },
                values: new object[] { new Guid("a251c876-81ce-4299-820d-ffc7a31fe436"), "Srednja škola" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GradeLevels",
                keyColumn: "Id",
                keyValue: new Guid("9b46dc05-75f8-49d8-a09d-19894e0c76a4"));

            migrationBuilder.DeleteData(
                table: "GradeLevels",
                keyColumn: "Id",
                keyValue: new Guid("a251c876-81ce-4299-820d-ffc7a31fe436"));
        }
    }
}
