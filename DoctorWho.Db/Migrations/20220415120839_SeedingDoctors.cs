using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class SeedingDoctors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tblDoctor",
                columns: new[] { "DoctorId", "BirthDate", "DoctorName", "DoctorNumber", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anjad Shaar", "First Doctor", new DateTime(2005, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2008, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1986, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ranen Halabi", "Second Doctor", new DateTime(2002, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2009, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1987, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shahd Shaar", "Third Doctor", new DateTime(2012, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(1988, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lina Khanna", "Fourth Doctor", null, null },
                    { 5, new DateTime(1989, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Majd Nabulsi", "Fifth Doctor", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblDoctor",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblDoctor",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblDoctor",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblDoctor",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblDoctor",
                keyColumn: "DoctorId",
                keyValue: 5);
        }
    }
}
