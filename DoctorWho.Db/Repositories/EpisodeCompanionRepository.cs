using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class EpisodeCompanionRepository
{
    private DoctorWhoDbContext _context;

    public EpisodeCompanionRepository(DoctorWhoDbContext context)
    {
        _context = context;
    }

    public void AddCompanionToEpisode(int episodeId, string companionName, string whoPlayed)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
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
                addCompanion.SaveChanges();
            }
        }
    }

    public static string GetCompanionsEpisode(int episodeId)
    {
        var result = DoctorWhoDbContext.fnCompanions(episodeId);
        return result;
    }
}