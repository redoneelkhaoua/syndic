using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Syndic.Persistence.EntityFramework.Migrations
{
    public partial class syndic3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "resultat_id_participant_fkey",
                table: "resultat");

            migrationBuilder.DropForeignKey(
                name: "resultat_id_vote_fkey",
                table: "resultat");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_creation",
                table: "vote",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_creation",
                table: "note",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_creation",
                table: "fichier",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_creation",
                table: "dossier",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "resultat_id_participant_fkey",
                table: "resultat",
                column: "id_participant",
                principalTable: "participant",
                principalColumn: "id_participant",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "resultat_id_vote_fkey",
                table: "resultat",
                column: "id_vote",
                principalTable: "vote",
                principalColumn: "id_vote",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "resultat_id_participant_fkey",
                table: "resultat");

            migrationBuilder.DropForeignKey(
                name: "resultat_id_vote_fkey",
                table: "resultat");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_creation",
                table: "vote",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_creation",
                table: "note",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_creation",
                table: "fichier",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_creation",
                table: "dossier",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "resultat_id_participant_fkey",
                table: "resultat",
                column: "id_participant",
                principalTable: "participant",
                principalColumn: "id_participant");

            migrationBuilder.AddForeignKey(
                name: "resultat_id_vote_fkey",
                table: "resultat",
                column: "id_vote",
                principalTable: "vote",
                principalColumn: "id_vote");
        }
    }
}
