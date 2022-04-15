using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class AddingView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"CREATE VIEW viewEpisodes AS "+
                                 "SELECT e.EpisodeId,e.SeriesNumber, e.EpisodeNumber,e.EpisodeType,e.Title,e.EpisodeDate,e.Note,a.AuthorName, "+
                                 "d.DoctorName, dbo.fnCompanions(e.EpisodeId) As Companions, dbo.fnEnemies(e.EpisodeId) AS Enemies "+ 
                                 "FROM tblEpisode e Left OUTER JOIN tblDoctor d on e.DoctorId=d.DoctorId "+
                                 "LEFT OUTER JOIN tblAuthor a on e.AuthorId=a.AuthorId; ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DROP VIEW [dbo].[viewEpisodes]");
        }
    }
}
