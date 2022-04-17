using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class AddingStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"CREATE PROCEDURE spSummariseEpisodes "+
                                 "AS "+
                                 "BEGIN "+
                                     "SELECT TOP(3) c.CompanionId,c.CompanionName, c.WhoPlayed "+
                                     "FROM tblEpisodeCompanion ec "+
                                     "INNER JOIN tblCompanion c "+ 
                                     "on ec.CompanionId=c.CompanionId "+
                                     "GROUP BY ec.CompanionId, c.CompanionName,c.WhoPlayed,c.CompanionId "+
                                     "ORDER BY COUNT(ec.CompanionId) DESC  "+

                                    "SELECT TOP(3)  e.EnemyId,e.EnemyName, e.[Description] "+
                                    "FROM tblEpisodeEnemy ee "+
                                    "INNER JOIN tblEnemy e  "+
                                    "on ee.EnemyId=e.EnemyId "+
                                    "GROUP BY ee.EnemyId, e.EnemyName,e.[Description],e.EnemyId "+
                                    "ORDER BY COUNT(ee.EnemyId) DESC "+
                                 "END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DROP PROCEDURE [dbo].[spSummariseEpisodes]");
        }
    }
}
