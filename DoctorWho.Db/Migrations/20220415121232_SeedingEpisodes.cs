using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class SeedingEpisodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tblEpisode",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodeDate", "EpisodeNumber", "EpisodeType", "Note", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2009, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Full", null, 1, "Welcome" },
                    { 2, 5, 1, new DateTime(2009, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Trailer", null, 1, "Test" },
                    { 3, 1, 1, new DateTime(2005, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Bonus", null, 1, "Be Better" },
                    { 4, 5, 3, new DateTime(2006, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Full", null, 2, "Warnning" },
                    { 5, 2, 3, new DateTime(2022, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Bonus", null, 2, "Warnning" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblEpisode",
                keyColumn: "EpisodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblEpisode",
                keyColumn: "EpisodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblEpisode",
                keyColumn: "EpisodeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblEpisode",
                keyColumn: "EpisodeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblEpisode",
                keyColumn: "EpisodeId",
                keyValue: 5);
        }
    }
}
