using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class EpisodeCompanionRepository
{
    private DoctorWhoDbContext _context;

    public EpisodeCompanionRepository(DoctorWhoDbContext context)
    {
        _context = context;
    }

    public async Task AddCompanionToEpisode(int episodeId, string companionName, string whoPlayed)
    {
        var episode = await _context.tblEpisodes.FindAsync(episodeId);
        if (episode != null)
        {
            var companion = new Companion
            {
                CompanionName = companionName,
                WhoPlayed = whoPlayed
            };
            using (var addCompanion = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                addCompanion.Attach(episode);
                episode.EpisodesCompanions.Add
                (
                    new EpisodeCompanion
                    {
                        Companion = companion
                    }
                );
                await addCompanion.SaveChangesAsync();
            }
        }
    }

    public static string? GetCompanionsEpisode(int episodeId)
    {
        var result = DoctorWhoDbContext.fnCompanions(episodeId);
        return result;
    }
}