namespace DoctorWho.Db.Repositories;

public class ViewEpisodesRepository
{
    private DoctorWhoDbContext _context;

    public ViewEpisodesRepository(DoctorWhoDbContext context)
    {
        _context = context;
    }

    public void ExecuteView()
    {
        var episodesView = _context.ViewEpisodes.ToList();
    }
}