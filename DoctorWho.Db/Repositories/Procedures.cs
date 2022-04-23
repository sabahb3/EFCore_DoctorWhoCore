using Dapper;
using Microsoft.Data.SqlClient;
namespace DoctorWho.Db.Repositories;

public static class Procedures
{
    public static async Task<(IEnumerable<Companion>, IEnumerable<Enemy>)> ExecuteProcedure()
    {
        var sql = "EXEC dbo.spSummariseEpisodes";
        using (var connection = new SqlConnection("Server=localhost;" +
                                                  "Database=DoctorWhoCore;" +
                                                  "Persist Security Info=False;User ID=sa;Password=S.11714778"))
        {
            await connection.OpenAsync().ConfigureAwait(false);
            var procedureResults = await connection.QueryMultipleAsync(sql);
            var companions = await procedureResults.ReadAsync<Companion>();
            var enemies = await procedureResults.ReadAsync<Enemy>();

            foreach (var result in companions)
                Console.WriteLine(
                    $"Companion Id: {result.CompanionId}, Companion name: {result.CompanionName}, Who played: {result.WhoPlayed}");
            Console.WriteLine();
            foreach (var result in enemies)
                Console.WriteLine(
                    $"Enemy Id: {result.EnemyId}, Enemy name: {result.EnemyName}, Description: {result.Description}");

            return (companions, enemies);
        }
    }
}