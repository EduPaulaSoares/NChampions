using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NChampions.Infra.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Championship",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChampionshipName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championship", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChampionshipGame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChampionshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HomeTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AwayTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HomeScore = table.Column<int>(type: "int", nullable: false),
                    AwayScore = table.Column<int>(type: "int", nullable: false),
                    GameDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionshipGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionshipGame_Championship_ChampionshipId",
                        column: x => x.ChampionshipId,
                        principalTable: "Championship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChampionshipGame_Team_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChampionshipGame_Team_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionshipTeam",
                columns: table => new
                {
                    ChampionshipsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionshipTeam", x => new { x.ChampionshipsId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_ChampionshipTeam_Championship_ChampionshipsId",
                        column: x => x.ChampionshipsId,
                        principalTable: "Championship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChampionshipTeam_Team_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipGame_AwayTeamId",
                table: "ChampionshipGame",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipGame_ChampionshipId",
                table: "ChampionshipGame",
                column: "ChampionshipId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipGame_HomeTeamId",
                table: "ChampionshipGame",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipTeam_TeamsId",
                table: "ChampionshipTeam",
                column: "TeamsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChampionshipGame");

            migrationBuilder.DropTable(
                name: "ChampionshipTeam");

            migrationBuilder.DropTable(
                name: "Championship");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
