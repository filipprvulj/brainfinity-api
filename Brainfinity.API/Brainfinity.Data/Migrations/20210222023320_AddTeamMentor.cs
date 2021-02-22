using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Brainfinity.Data.Migrations
{
    public partial class AddTeamMentor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TeamMentorId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeamMentors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMentors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TeamMentorId",
                table: "AspNetUsers",
                column: "TeamMentorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TeamMentors_TeamMentorId",
                table: "AspNetUsers",
                column: "TeamMentorId",
                principalTable: "TeamMentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TeamMentors_TeamMentorId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TeamMentors");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TeamMentorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TeamMentorId",
                table: "AspNetUsers");
        }
    }
}
