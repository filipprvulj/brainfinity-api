using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Brainfinity.Data.Migrations
{
    public partial class AddGradeToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GradeId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GradeId",
                table: "AspNetUsers",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Grades_GradeId",
                table: "AspNetUsers",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Grades_GradeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GradeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "AspNetUsers");
        }
    }
}
