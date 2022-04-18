using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Syndic.Persistence.EntityFramework.Migrations
{
    public partial class syndic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id_category = table.Column<int>(type: "integer", nullable: false),
                    category_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("category_pkey", x => x.id_category);
                });

            migrationBuilder.CreateTable(
                name: "participant",
                columns: table => new
                {
                    id_participant = table.Column<int>(type: "integer", nullable: false),
                    participant_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("participant_pkey", x => x.id_participant);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    id_Status = table.Column<int>(type: "integer", nullable: false),
                    status_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Status_pkey", x => x.id_Status);
                });

            migrationBuilder.CreateTable(
                name: "case",
                columns: table => new
                {
                    id_case = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    creation_Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    category = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("case_pkey", x => x.id_case);
                    table.ForeignKey(
                        name: "case_category_fkey",
                        column: x => x.category,
                        principalTable: "category",
                        principalColumn: "id_category");
                    table.ForeignKey(
                        name: "case_Status_fkey",
                        column: x => x.Status,
                        principalTable: "Status",
                        principalColumn: "id_Status");
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    id_File = table.Column<int>(type: "integer", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    file = table.Column<string>(type: "text", nullable: true),
                    creation_Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    type = table.Column<string>(type: "text", nullable: true),
                    id_case = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("File_pkey", x => x.id_File);
                    table.ForeignKey(
                        name: "File_id_case_fkey",
                        column: x => x.id_case,
                        principalTable: "case",
                        principalColumn: "id_case");
                });

            migrationBuilder.CreateTable(
                name: "note",
                columns: table => new
                {
                    id_note = table.Column<int>(type: "integer", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    creation_Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    type = table.Column<string>(type: "text", nullable: true),
                    id_case = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("note_pkey", x => x.id_note);
                    table.ForeignKey(
                        name: "note_id_dase_fkey",
                        column: x => x.id_case,
                        principalTable: "case",
                        principalColumn: "id_case");
                });

            migrationBuilder.CreateTable(
                name: "vote",
                columns: table => new
                {
                    id_vote = table.Column<int>(type: "integer", nullable: false),
                    titre = table.Column<string>(type: "text", nullable: true),
                    creation_Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    type = table.Column<string>(type: "text", nullable: true),
                    id_dase = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("vote_pkey", x => x.id_vote);
                    table.ForeignKey(
                        name: "vote_id_dase_fkey",
                        column: x => x.id_dase,
                        principalTable: "case",
                        principalColumn: "id_case");
                });

            migrationBuilder.CreateTable(
                name: "choice",
                columns: table => new
                {
                    id_choice = table.Column<int>(type: "integer", nullable: false),
                    choice = table.Column<string>(type: "text", nullable: true),
                    id_vote = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("choice_pkey", x => x.id_choice);
                    table.ForeignKey(
                        name: "choice_id_vote_fkey",
                        column: x => x.id_vote,
                        principalTable: "vote",
                        principalColumn: "id_vote");
                });

            migrationBuilder.CreateTable(
                name: "results",
                columns: table => new
                {
                    id_vote = table.Column<int>(type: "integer", nullable: false),
                    id_participant = table.Column<int>(type: "integer", nullable: false),
                    id_choice = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("results_pkey", x => new { x.id_participant, x.id_vote });
                    table.ForeignKey(
                        name: "results_id_choice_fkey",
                        column: x => x.id_choice,
                        principalTable: "choice",
                        principalColumn: "id_choice");
                    table.ForeignKey(
                        name: "results_id_participant_fkey",
                        column: x => x.id_participant,
                        principalTable: "participant",
                        principalColumn: "id_participant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "results_id_vote_fkey",
                        column: x => x.id_vote,
                        principalTable: "vote",
                        principalColumn: "id_vote",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_case_category",
                table: "case",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "IX_case_Status",
                table: "case",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_choice_id_vote",
                table: "choice",
                column: "id_vote");

            migrationBuilder.CreateIndex(
                name: "IX_File_id_case",
                table: "File",
                column: "id_case");

            migrationBuilder.CreateIndex(
                name: "IX_note_id_case",
                table: "note",
                column: "id_case");

            migrationBuilder.CreateIndex(
                name: "IX_results_id_choice",
                table: "results",
                column: "id_choice");

            migrationBuilder.CreateIndex(
                name: "IX_results_id_vote",
                table: "results",
                column: "id_vote");

            migrationBuilder.CreateIndex(
                name: "IX_vote_id_dase",
                table: "vote",
                column: "id_dase");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "note");

            migrationBuilder.DropTable(
                name: "results");

            migrationBuilder.DropTable(
                name: "choice");

            migrationBuilder.DropTable(
                name: "participant");

            migrationBuilder.DropTable(
                name: "vote");

            migrationBuilder.DropTable(
                name: "case");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
