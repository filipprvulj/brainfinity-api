using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Brainfinity.Data.Migrations
{
    public partial class AddAssignmentGroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Grades_GradeId",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "GradeId",
                table: "Assignments",
                newName: "AssignmentGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_GradeId",
                table: "Assignments",
                newName: "IX_Assignments_AssignmentGroupId");

            migrationBuilder.CreateTable(
                name: "AssignmentGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompetitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignmentGroups_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentGroups_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentGroups_CompetitionId",
                table: "AssignmentGroups",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentGroups_GradeId",
                table: "AssignmentGroups",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AssignmentGroups_AssignmentGroupId",
                table: "Assignments",
                column: "AssignmentGroupId",
                principalTable: "AssignmentGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AssignmentGroups_AssignmentGroupId",
                table: "Assignments");

            migrationBuilder.DropTable(
                name: "AssignmentGroups");

            migrationBuilder.RenameColumn(
                name: "AssignmentGroupId",
                table: "Assignments",
                newName: "GradeId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_AssignmentGroupId",
                table: "Assignments",
                newName: "IX_Assignments_GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Grades_GradeId",
                table: "Assignments",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
