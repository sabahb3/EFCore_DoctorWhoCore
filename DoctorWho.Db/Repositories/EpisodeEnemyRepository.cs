using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class EpisodeEnemyRepository
{
    private DoctorWhoDbContext _context;

    public EpisodeEnemyRepository(DoctorWhoDbContext context)
    {
        _context = context;
    }

    public async Task AddEnemyToEpisode(int episodeId, string enemyName, string description)
    {
        var episode = await _context.tblEpisodes.FindAsync(episodeId);
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
                await addEnemy.SaveChangesAsync();
            }
        }
    }
    public static string GetEnemiesEpisode(int episodeId)
    {
        var result = DoctorWhoDbContext.fnEnemies(episodeId);
        return result;
    }
}