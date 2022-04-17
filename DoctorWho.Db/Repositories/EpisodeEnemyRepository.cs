using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class EpisodeEnemyRepository
{
    private DoctorWhoDbContext _context;

    public EpisodeEnemyRepository(DoctorWhoDbContext context)
    {
        _context = context;
    }

    public void AddEnemyToEpisode(int episodeId, string enemyName, string description)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
        if (episode != null)
        {
            var enemy = new Enemy
            {
                EnemyName = enemyName,
                Description = description
            };
            using (var addEnemy = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
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
    public static string GetEnemiesEpisode(int episodeId)
    {
        var result = DoctorWhoDbContext.fnEnemies(episodeId);
        return result;
    }
}