using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class ViewEpisodesRepository
{
    private DoctorWhoDbContext _context;

    public ViewEpisodesRepository(DoctorWhoDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ViewEpisodes>> ExecuteView()
    {
        var episodesView = await _context.ViewEpisodes.ToListAsync();
        return episodesView;
    }
}