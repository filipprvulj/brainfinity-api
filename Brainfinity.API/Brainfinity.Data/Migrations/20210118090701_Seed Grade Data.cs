using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Brainfinity.Data.Migrations
{
    public partial class SeedGradeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "GradeLevelId", "Name" },
                values: new object[,]
                {
                    { new Guid("595375e5-c4a7-7a51-7deb-3ef7c0d65b62"), new Guid("9b46dc05-75f8-49d8-a09d-19894e0c76a4"), "5. razred" },
                    { new Guid("590a46cb-7104-9f85-8706-fd2142ea12e6"), new Guid("9b46dc05-75f8-49d8-a09d-19894e0c76a4"), "6. razred" },
                    { new Guid("48ec597e-a374-dc80-6a95-a2792ca27db1"), new Guid("9b46dc05-75f8-49d8-a09d-19894e0c76a4"), "7. razred" },
                    { new Guid("24bc1870-6df9-83ac-8937-58e12d02036c"), new Guid("9b46dc05-75f8-49d8-a09d-19894e0c76a4"), "8. razred" },
                    { new Guid("543b42fc-d3ec-90eb-2782-c3bf0b0e182a"), new Guid("a251c876-81ce-4299-820d-ffc7a31fe436"), "1. razred" },
                    { new Guid("e3eb45e7-e68b-10d1-286b-6d0f7145f10a"), new Guid("a251c876-81ce-4299-820d-ffc7a31fe436"), "2. razred" },
                    { new Guid("ba1a5ac3-d30e-8073-a642-3806e7f13e78"), new Guid("a251c876-81ce-4299-820d-ffc7a31fe436"), "3. razred" },
                    { new Guid("f3b1c158-e9b2-ca45-e9c3-b6a0130fd257"), new Guid("a251c876-81ce-4299-820d-ffc7a31fe436"), "4. razred" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("24bc1870-6df9-83ac-8937-58e12d02036c"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("48ec597e-a374-dc80-6a95-a2792ca27db1"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("543b42fc-d3ec-90eb-2782-c3bf0b0e182a"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("590a46cb-7104-9f85-8706-fd2142ea12e6"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("595375e5-c4a7-7a51-7deb-3ef7c0d65b62"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("ba1a5ac3-d30e-8073-a642-3806e7f13e78"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("e3eb45e7-e68b-10d1-286b-6d0f7145f10a"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("f3b1c158-e9b2-ca45-e9c3-b6a0130fd257"));
        }
    }
}
