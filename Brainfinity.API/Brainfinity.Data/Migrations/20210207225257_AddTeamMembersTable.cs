using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Brainfinity.Data.Migrations
{
    public partial class AddTeamMembersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AspNetUsers_UserId",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Assignments",
                newName: "MainExaminerId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_UserId",
                table: "Assignments",
                newName: "IX_Assignments_MainExaminerId");

            migrationBuilder.AddColumn<string>(
                name: "TeamName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_AspNetUsers_TeamId",
                        column: x => x.TeamId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMembers",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AspNetUsers_MainExaminerId",
                table: "Assignments",
                column: "MainExaminerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AspNetUsers_MainExaminerId",
                table: "Assignments");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "TeamName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "MainExaminerId",
                table: "Assignments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_MainExaminerId",
                table: "Assignments",
                newName: "IX_Assignments_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AspNetUsers_UserId",
                table: "Assignments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
