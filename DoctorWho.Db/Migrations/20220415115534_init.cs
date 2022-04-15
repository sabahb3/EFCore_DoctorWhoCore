using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAuthor",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAuthor", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "tblCompanion",
                columns: table => new
                {
                    CompanionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhoPlayed = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCompanion", x => x.CompanionId);
                });

            migrationBuilder.CreateTable(
                name: "tblDoctor",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstEpisodeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastEpisodeDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDoctor", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "tblEnemy",
                columns: table => new
                {
                    EnemyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnemyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEnemy", x => x.EnemyId);
                });

            migrationBuilder.CreateTable(
                name: "tblEpisode",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesNumber = table.Column<int>(type: "int", nullable: false),
                    EpisodeNumber = table.Column<int>(type: "int", nullable: false),
                    EpisodeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EpisodeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEpisode", x => x.EpisodeId);
                    table.CheckConstraint("CK_tblEpisode_EpisodeType_Enum", "[EpisodeType] IN (N'Trailer', N'Bonus', N'Full')");
                    table.ForeignKey(
                        name: "FK_tblEpisode_tblAuthor_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "tblAuthor",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblEpisode_tblDoctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "tblDoctor",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblEpisodeCompanion",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(type: "int", nullable: false),
                    CompanionId = table.Column<int>(type: "int", nullable: false),
                    EpisodeCompanionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEpisodeCompanion", x => new { x.EpisodeId, x.CompanionId });
                    table.ForeignKey(
                        name: "FK_tblEpisodeCompanion_tblCompanion_CompanionId",
                        column: x => x.CompanionId,
                        principalTable: "tblCompanion",
                        principalColumn: "CompanionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblEpisodeCompanion_tblEpisode_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "tblEpisode",
                        principalColumn: "EpisodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblEpisodeEnemy",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(type: "int", nullable: false),
                    EnemyId = table.Column<int>(type: "int", nullable: false),
                    EpisodeEnemyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEpisodeEnemy", x => new { x.EpisodeId, x.EnemyId });
                    table.ForeignKey(
                        name: "FK_tblEpisodeEnemy_tblEnemy_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "tblEnemy",
                        principalColumn: "EnemyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblEpisodeEnemy_tblEpisode_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "tblEpisode",
                        principalColumn: "EpisodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblEpisode_AuthorId",
                table: "tblEpisode",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEpisode_DoctorId",
                table: "tblEpisode",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEpisodeCompanion_CompanionId",
                table: "tblEpisodeCompanion",
                column: "CompanionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEpisodeEnemy_EnemyId",
                table: "tblEpisodeEnemy",
                column: "EnemyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEpisodeCompanion");

            migrationBuilder.DropTable(
                name: "tblEpisodeEnemy");

            migrationBuilder.DropTable(
                name: "tblCompanion");

            migrationBuilder.DropTable(
                name: "tblEnemy");

            migrationBuilder.DropTable(
                name: "tblEpisode");

            migrationBuilder.DropTable(
                name: "tblAuthor");

            migrationBuilder.DropTable(
                name: "tblDoctor");
        }
    }
}
