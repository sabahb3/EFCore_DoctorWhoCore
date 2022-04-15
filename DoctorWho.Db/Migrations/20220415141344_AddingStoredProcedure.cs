using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class AddingStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"CREATE PROCEDURE spSummariseEpisodes"+
                                 "AS"+
                                "BEGIN"+
                                    "SELECT TOP(3) COUNT(ec.CompanionId) AS NumberOfAppearances,c.CompanionName, c.WhoPlayed"+
                                    "FROM tblEpisodeCompanion ec"+
                                    "INNER JOIN tblCompanion c"+ 
                                    "on ec.CompanionId=c.CompanionId"+
                                    "GROUP BY ec.CompanionId, c.CompanionName,c.WhoPlayed"+
                                    "ORDER BY NumberOfAppearances DESC"+

                                    "SELECT TOP(3) COUNT(ee.EnemyId) AS NumberOfAppearances,e.EnemyName, e.[Description]"+
                                    "FROM tblEpisodeEnemy ee"+
                                    "INNER JOIN tblEnemy e"+ 
                                    "on ee.EnemyId=e.EnemyId"+
                                    "GROUP BY ee.EnemyId, e.EnemyName,e.[Description]"+
                                    "ORDER BY NumberOfAppearances DESC"+
                                 "END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DROP PROCEDURE [dbo].[spSummariseEpisodes]");
        }
    }
}
