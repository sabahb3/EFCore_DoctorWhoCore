using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class SeedingCompanions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tblCompanion",
                columns: new[] { "CompanionId", "CompanionName", "WhoPlayed" },
                values: new object[,]
                {
                    { 1, "Ameera Ameer", "Ameera Surakji" },
                    { 2, "khalid Ali", "khalid Toma" },
                    { 3, "Aya Khalid", "Aya Jamal" },
                    { 4, "Samar Samer", "Samar Rsas" },
                    { 5, "Duaa Aqel", "Dalal Aqel" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblCompanion",
                keyColumn: "CompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblCompanion",
                keyColumn: "CompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblCompanion",
                keyColumn: "CompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblCompanion",
                keyColumn: "CompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblCompanion",
                keyColumn: "CompanionId",
                keyValue: 5);
        }
    }
}
