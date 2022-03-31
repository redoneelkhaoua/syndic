using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Syndic.domain.Migrations
{
    public partial class Syndic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorie",
                columns: table => new
                {
                    id_categorie = table.Column<int>(type: "integer", nullable: false),
                    nom_categorie = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("categorie_pkey", x => x.id_categorie);
                });

            migrationBuilder.CreateTable(
                name: "participant",
                columns: table => new
                {
                    id_participant = table.Column<int>(type: "integer", nullable: false),
                    nom = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("participant_pkey", x => x.id_participant);
                });

            migrationBuilder.CreateTable(
                name: "statut",
                columns: table => new
                {
                    id_statut = table.Column<int>(type: "integer", nullable: false),
                    nom_statut = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("statut_pkey", x => x.id_statut);
                });

            migrationBuilder.CreateTable(
                name: "dossier",
                columns: table => new
                {
                    id_dossier = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    date_creation = table.Column<DateOnly>(type: "date", nullable: true),
                    categorie = table.Column<int>(type: "integer", nullable: true),
                    statut = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("dossier_pkey", x => x.id_dossier);
                    table.ForeignKey(
                        name: "dossier_categorie_fkey",
                        column: x => x.categorie,
                        principalTable: "categorie",
                        principalColumn: "id_categorie");
                    table.ForeignKey(
                        name: "dossier_statut_fkey",
                        column: x => x.statut,
                        principalTable: "statut",
                        principalColumn: "id_statut");
                });

            migrationBuilder.CreateTable(
                name: "fichier",
                columns: table => new
                {
                    id_fichier = table.Column<int>(type: "integer", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    fichier = table.Column<string>(type: "text", nullable: true),
                    date_creation = table.Column<DateOnly>(type: "date", nullable: true),
                    typee = table.Column<string>(type: "text", nullable: true),
                    id_dossier = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("fichier_pkey", x => x.id_fichier);
                    table.ForeignKey(
                        name: "fichier_id_dossier_fkey",
                        column: x => x.id_dossier,
                        principalTable: "dossier",
                        principalColumn: "id_dossier");
                });

            migrationBuilder.CreateTable(
                name: "note",
                columns: table => new
                {
                    id_note = table.Column<int>(type: "integer", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    date_creation = table.Column<DateOnly>(type: "date", nullable: true),
                    typee = table.Column<string>(type: "text", nullable: true),
                    id_dossier = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("note_pkey", x => x.id_note);
                    table.ForeignKey(
                        name: "note_id_dossier_fkey",
                        column: x => x.id_dossier,
                        principalTable: "dossier",
                        principalColumn: "id_dossier");
                });

            migrationBuilder.CreateTable(
                name: "vote",
                columns: table => new
                {
                    id_vote = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    date_creation = table.Column<DateOnly>(type: "date", nullable: true),
                    typee = table.Column<string>(type: "text", nullable: true),
                    id_dossier = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("vote_pkey", x => x.id_vote);
                    table.ForeignKey(
                        name: "vote_id_dossier_fkey",
                        column: x => x.id_dossier,
                        principalTable: "dossier",
                        principalColumn: "id_dossier");
                });

            migrationBuilder.CreateTable(
                name: "choix",
                columns: table => new
                {
                    id_choix = table.Column<int>(type: "integer", nullable: false),
                    choix = table.Column<string>(type: "text", nullable: true),
                    id_vote = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("choix_pkey", x => x.id_choix);
                    table.ForeignKey(
                        name: "choix_id_vote_fkey",
                        column: x => x.id_vote,
                        principalTable: "vote",
                        principalColumn: "id_vote");
                });

            migrationBuilder.CreateTable(
                name: "resultat",
                columns: table => new
                {
                    id_vote = table.Column<int>(type: "integer", nullable: false),
                    id_participant = table.Column<int>(type: "integer", nullable: false),
                    id_choix = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("resultat_pkey", x => new { x.id_participant, x.id_vote });
                    table.ForeignKey(
                        name: "resultat_id_choix_fkey",
                        column: x => x.id_choix,
                        principalTable: "choix",
                        principalColumn: "id_choix");
                    table.ForeignKey(
                        name: "resultat_id_participant_fkey",
                        column: x => x.id_participant,
                        principalTable: "participant",
                        principalColumn: "id_participant");
                    table.ForeignKey(
                        name: "resultat_id_vote_fkey",
                        column: x => x.id_vote,
                        principalTable: "vote",
                        principalColumn: "id_vote");
                });

            migrationBuilder.CreateIndex(
                name: "IX_choix_id_vote",
                table: "choix",
                column: "id_vote");

            migrationBuilder.CreateIndex(
                name: "IX_dossier_categorie",
                table: "dossier",
                column: "categorie");

            migrationBuilder.CreateIndex(
                name: "IX_dossier_statut",
                table: "dossier",
                column: "statut");

            migrationBuilder.CreateIndex(
                name: "IX_fichier_id_dossier",
                table: "fichier",
                column: "id_dossier");

            migrationBuilder.CreateIndex(
                name: "IX_note_id_dossier",
                table: "note",
                column: "id_dossier");

            migrationBuilder.CreateIndex(
                name: "IX_resultat_id_choix",
                table: "resultat",
                column: "id_choix");

            migrationBuilder.CreateIndex(
                name: "IX_resultat_id_vote",
                table: "resultat",
                column: "id_vote");

            migrationBuilder.CreateIndex(
                name: "IX_vote_id_dossier",
                table: "vote",
                column: "id_dossier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fichier");

            migrationBuilder.DropTable(
                name: "note");

            migrationBuilder.DropTable(
                name: "resultat");

            migrationBuilder.DropTable(
                name: "choix");

            migrationBuilder.DropTable(
                name: "participant");

            migrationBuilder.DropTable(
                name: "vote");

            migrationBuilder.DropTable(
                name: "dossier");

            migrationBuilder.DropTable(
                name: "categorie");

            migrationBuilder.DropTable(
                name: "statut");
        }
    }
}
