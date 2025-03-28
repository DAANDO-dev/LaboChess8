using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaboChess8.Migrations
{
    /// <inheritdoc />
    public partial class CreateMatchups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matchups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Result = table.Column<int>(type: "int", nullable: false),
                    Round = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    WhiteId = table.Column<int>(type: "int", nullable: false),
                    BlackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matchups_Members_BlackId",
                        column: x => x.BlackId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Matchups_Members_WhiteId",
                        column: x => x.WhiteId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Matchups_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matchups_BlackId",
                table: "Matchups",
                column: "BlackId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchups_TournamentId",
                table: "Matchups",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchups_WhiteId",
                table: "Matchups",
                column: "WhiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matchups");
        }
    }
}
