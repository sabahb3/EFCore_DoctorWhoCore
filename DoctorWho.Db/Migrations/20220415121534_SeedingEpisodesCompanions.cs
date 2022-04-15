using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class SeedingEpisodesCompanions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tblEpisodeCompanion",
                columns: new[] { "CompanionId", "EpisodeId", "EpisodeCompanionId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 3, 1, 2 },
                    { 4, 2, 3 },
                    { 1, 3, 4 },
                    { 4, 4, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblEpisodeCompanion",
                keyColumns: new[] { "CompanionId", "EpisodeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "tblEpisodeCompanion",
                keyColumns: new[] { "CompanionId", "EpisodeId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "tblEpisodeCompanion",
                keyColumns: new[] { "CompanionId", "EpisodeId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "tblEpisodeCompanion",
                keyColumns: new[] { "CompanionId", "EpisodeId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "tblEpisodeCompanion",
                keyColumns: new[] { "CompanionId", "EpisodeId" },
                keyValues: new object[] { 4, 4 });
        }
    }
}
