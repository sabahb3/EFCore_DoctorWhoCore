using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class AddingFunctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"CREATE FUNCTION dbo.fnCompanions(@EpisodeId int) " +
                                 "RETURNS VARCHAR(1000) " +
                                 "AS"+
                                "BEGIN"+
                                    "DECLARE @companions AS VARCHAR(1000);"+
                                     "SELECT @companions = COALESCE(@companions + ', '+CompanionName, CompanionName) from tblCompanion"+
                                    "WHERE CompanionId IN(SELECT CompanionId from tblEpisodeCompanion where EpisodeId=@EpisodeId)"+
                                    "RETURN @companions;"+ 
                                 "END");
            
            migrationBuilder.Sql($"CREATE FUNCTION dbo.fnEnemies(@EpisodeId int)"+
                                "RETURNS VARCHAR(1000)"+
                                "AS"+
                                "BEGIN"+
                                    "DECLARE @enemies AS VARCHAR(1000);"+
                                    "SELECT @enemies = COALESCE(@enemies + ', '+EnemyName, EnemyName) FROM tblEnemy"+
                                    "WHERE EnemyId IN(SELECT EnemyId from tblEpisodeEnemy where EpisodeId=@EpisodeId)"+
                                    "RETURN @enemies;"+
                                "END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DROP FUNCTION [dbo].[fnCompanions];");
            migrationBuilder.Sql($"DROP FUNCTION [dbo].[fnEnemies];");
        }
    }
}
