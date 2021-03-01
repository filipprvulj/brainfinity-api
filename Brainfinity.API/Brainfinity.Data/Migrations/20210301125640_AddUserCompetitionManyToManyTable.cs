using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Brainfinity.Data.Migrations
{
    public partial class AddUserCompetitionManyToManyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompetitionUser",
                columns: table => new
                {
                    CompetitionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionUser", x => new { x.CompetitionsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_CompetitionUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionUser_Competitions_CompetitionsId",
                        column: x => x.CompetitionsId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionUser_UsersId",
                table: "CompetitionUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionUser");
        }
    }
}
