namespace DoctorWho.Db.Repositories;

using Enumerations;
using Microsoft.EntityFrameworkCore;

public class EpisodeRepository
{
    private DoctorWhoDbContext _context;

    public EpisodeRepository(DoctorWhoDbContext context)
    {
        _context = context;
    }

    public async Task CreateEpisode(Episode episode)
    {
        var author = await _context.tblAuthors.FindAsync(episode.AuthorId);
        var doctor = await _context.tblDoctors.FindAsync(episode.DoctorId);
        if (author != null && doctor != null)
        {
            _context.tblEpisodes.Add(episode);
            await  _context.SaveChangesAsync();
        }
    }

    public async Task UpdateSeriesNumber(int episodeId, int seriesNumber)
    {
        var episode = await _context.tblEpisodes.FindAsync(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.SeriesNumber = seriesNumber;
                updateContext.Entry(episode).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateEpisodeNumber(int episodeId, int episodeNumber)
    {
        var episode = await _context.tblEpisodes.FindAsync(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.EpisodeNumber = episodeNumber;
                updateContext.Entry(episode).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateEpisodeType(int episodeId, EpisodeType episodeType)
    {
        var episode = await _context.tblEpisodes.FindAsync(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.EpisodeType = episodeType;
                updateContext.Entry(episode).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateTitle(int episodeId, string title)
    {
        var episode = await _context.tblEpisodes.FindAsync(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.Title = title;
                updateContext.Entry(episode).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateEpisodeDate(int episodeId, DateTime episodeDate)
    {
        var episode = await _context.tblEpisodes.FindAsync(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.EpisodeDate = episodeDate;
                updateContext.Entry(episode).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateNote(int episodeId, string note)
    {
        var episode = await _context.tblEpisodes.FindAsync(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.Note = note;
                updateContext.Entry(episode).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateAuthor(int episodeId, int authorId)
    {
        var episode = await _context.tblEpisodes.FindAsync(episodeId);
        var author = await _context.tblAuthors.FindAsync(authorId);
        if (episode != null && author != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.AuthorId = authorId;
                updateContext.Entry(episode).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateDoctor(int episodeId, int doctorId)
    {
        var episode = await _context.tblEpisodes.FindAsync(episodeId);
        var doctor = await _context.tblDoctors.FindAsync(doctorId);
        if (episode != null && doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.DoctorId = doctorId;
                updateContext.Entry(episode).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateEpisode(int episodeId, int seriesNumber, int episodeNumber)
    {
        var episode = await _context.tblEpisodes.FindAsync(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.SeriesNumber = seriesNumber;
                episode.EpisodeNumber = episodeNumber;
                updateContext.Entry(episode).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateEpisode(int episodeId, int seriesNumber, int episodeNumber, EpisodeType type)
    {
        var episode = await _context.tblEpisodes.FindAsync(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.SeriesNumber = seriesNumber;
                episode.EpisodeNumber = episodeNumber;
                episode.EpisodeType = type;
                updateContext.Entry(episode).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateEpisode(int episodeId, int seriesNumber, int episodeNumber, EpisodeType type, string title)
    {
        var episode = await _context.tblEpisodes.FindAsync(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.SeriesNumber = seriesNumber;
                episode.EpisodeNumber = episodeNumber;
                episode.EpisodeType = type;
                episode.Title = title;
                updateContext.Entry(episode).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateEpisode(int episodeId, int seriesNumber, int episodeNumber, EpisodeType type, string title,
        DateTime date)
    {
        var episode = await _context.tblEpisodes.FindAsync(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.SeriesNumber = seriesNumber;
                episode.EpisodeNumber = episodeNumber;
                episode.EpisodeType = type;
                episode.Title = title;
                episode.EpisodeDate = date;
                updateContext.Entry(episode).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateEpisode(int episodeId, int seriesNumber, int episodeNumber, EpisodeType type, string title,
        DateTime date, string note)
    {
        var episode = await _context.tblEpisodes.FindAsync(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.SeriesNumber = seriesNumber;
                episode.EpisodeNumber = episodeNumber;
                episode.EpisodeType = type;
                episode.Title = title;
                episode.EpisodeDate = date;
                episode.Note = note;
                updateContext.Entry(episode).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateEpisode(int episodeId, int seriesNumber, int episodeNumber, EpisodeType type, string title,
        DateTime date, string? note, int authorId)
    {
        var episode = await _context.tblEpisodes.FindAsync(episodeId);
        var author = await _context.tblAuthors.FindAsync(authorId);
        if (episode != null && author != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.SeriesNumber = seriesNumber;
                episode.EpisodeNumber = episodeNumber;
                episode.EpisodeType = type;
                episode.Title = title;
                episode.EpisodeDate = date;
                episode.Note = note;
                episode.AuthorId = authorId;
                updateContext.Entry(episode).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateEpisode(int episodeId, int seriesNumber, int episodeNumber, EpisodeType type, string title,
        DateTime date, string? note, int authorId, int doctorId)
    {
        var episode = await _context.tblEpisodes.FindAsync(episodeId);
        var author = await _context.tblAuthors.FindAsync(authorId);
        var doctor = await _context.tblDoctors.FindAsync(doctorId);
        if (episode != null && author != null && doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.SeriesNumber = seriesNumber;
                episode.EpisodeNumber = episodeNumber;
                episode.EpisodeType = type;
                episode.Title = title;
                episode.EpisodeDate = date;
                episode.Note = note;
                episode.AuthorId = authorId;
                episode.DoctorId = doctorId;
                updateContext.Entry(episode).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task DeleteEpisode(int episodeId)
    {
        var episode = await _context.tblEpisodes.FindAsync(episodeId);
        if (episode != null)
            using (var deleteContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                deleteContext.tblEpisodes.Remove(episode);
                await deleteContext.SaveChangesAsync();
            }
    }
}