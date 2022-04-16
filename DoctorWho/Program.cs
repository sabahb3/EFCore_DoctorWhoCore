// See https://aka.ms/new-console-template for more information

using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static DoctorWhoDbContext _context = new();

    public static void Main()
    {
        ExecuteView();
        Console.WriteLine();
        var companions = GetCompanionsEpisode(1);
        Console.WriteLine(companions);
        Console.WriteLine();
        var enemies = GetEnemiesEpisode(1);
        Console.WriteLine(enemies);
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

    public static string GetEnemiesEpisode(int episodeId)
    {
        var result = DoctorWhoDbContext.fnEnemies(episodeId);
        return result;
    }

    public static void AddEnemyToEpisode(int episodeId, string enemyName, string description)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
        if (episode != null)
        {
            var enemy = new Enemy
            {
                EnemyName = enemyName,
                Description = description
            };
            using (var addEnemy = new DoctorWhoDbContext())
            {
                addEnemy.Attach(episode);
                episode.EpisodesEnemies.Add
                (
                    new EpisodeEnemy
                    {
                        Enemy = enemy
                    }
                );
                addEnemy.SaveChanges();
            }
        }
    }

    public static void AddCompanionToEpisode(int episodeId, string companionName, string whoPlayed)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
        if (episode != null)
        {
            var companion = new Companion
            {
                CompanionName = companionName,
                WhoPlayed = whoPlayed
            };
            using (var addCompanion = new DoctorWhoDbContext())
            {
                addCompanion.Attach(episode);
                episode.EpisodesCompanions.Add
                (
                    new EpisodeCompanion
                    {
                        Companion = companion
                    }
                );
                addCompanion.SaveChanges();
            }
        }
    }

    public static void GetAllDoctor()
    {
        var doctors = _context.tblDoctors.ToList();
    }

    public static Enemy? GetEnemyById(int enemyId)
    {
        return _context.tblEnemies.Find(enemyId);
    }

    public static Companion? GetCompanionById(int companionId)
    {
        return _context.tblCompanions.Find(companionId);
    }
}