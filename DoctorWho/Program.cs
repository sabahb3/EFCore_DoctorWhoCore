// See https://aka.ms/new-console-template for more information

using Dapper;
using DoctorWho.Db;
using Microsoft.Data.SqlClient;

internal class Program
{
    private static DoctorWhoDbContext _context = new();

    public static async Task Main()
    {
        ExecuteView();
        Console.WriteLine();
        var companions = GetCompanionsEpisode(1);
        Console.WriteLine(companions);
        Console.WriteLine();
        var result = await ExecuteProcedure();
    }

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

    public static void ExecuteView()
    {
        var episodesView = _context.ViewEpisodes.ToList();
    }

    public static string GetCompanionsEpisode(int episodeId)
    {
        var result = DoctorWhoDbContext.fnCompanions(episodeId);
        return result;
    }


}