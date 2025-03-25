using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaboChess8.Migrations
{
    /// <inheritdoc />
    public partial class RenameTournamentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CreateTournaments",
                table: "CreateTournaments");

            migrationBuilder.RenameTable(
                name: "CreateTournaments",
                newName: "Tournaments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tournaments",
                table: "Tournaments",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tournaments",
                table: "Tournaments");

            migrationBuilder.RenameTable(
                name: "Tournaments",
                newName: "CreateTournaments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreateTournaments",
                table: "CreateTournaments",
                column: "Id");
        }
    }
}
