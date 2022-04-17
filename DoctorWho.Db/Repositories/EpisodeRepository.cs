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

    public void CreateEpisode(Episode episode)
    {
        var author = _context.tblAuthors.Find(episode.AuthorId);
        var doctor = _context.tblDoctors.Find(episode.DoctorId);
        if (author != null && doctor != null)
        {
            _context.tblEpisodes.Add(episode);
            _context.SaveChanges();
        }
    }

    public void UpdateSeriesNumber(int episodeId, int seriesNumber)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.SeriesNumber = seriesNumber;
                updateContext.Entry(episode).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateEpisodeNumber(int episodeId, int episodeNumber)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.EpisodeNumber = episodeNumber;
                updateContext.Entry(episode).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateEpisodeType(int episodeId, EpisodeType episodeType)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.EpisodeType = episodeType;
                updateContext.Entry(episode).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateTitle(int episodeId, string title)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.Title = title;
                updateContext.Entry(episode).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateEpisodeDate(int episodeId, DateTime episodeDate)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.EpisodeDate = episodeDate;
                updateContext.Entry(episode).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateNote(int episodeId, string note)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.Note = note;
                updateContext.Entry(episode).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateAuthor(int episodeId, int authorId)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
        var author = _context.tblAuthors.Find(authorId);
        if (episode != null && author != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.AuthorId = authorId;
                updateContext.Entry(episode).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateDoctor(int episodeId, int doctorId)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
        var doctor = _context.tblDoctors.Find(doctorId);
        if (episode != null && doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.DoctorId = doctorId;
                updateContext.Entry(episode).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateEpisode(int episodeId, int seriesNumber, int episodeNumber)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.SeriesNumber = seriesNumber;
                episode.EpisodeNumber = episodeNumber;
                updateContext.Entry(episode).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateEpisode(int episodeId, int seriesNumber, int episodeNumber, EpisodeType type)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.SeriesNumber = seriesNumber;
                episode.EpisodeNumber = episodeNumber;
                episode.EpisodeType = type;
                updateContext.Entry(episode).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateEpisode(int episodeId, int seriesNumber, int episodeNumber, EpisodeType type, string title)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.SeriesNumber = seriesNumber;
                episode.EpisodeNumber = episodeNumber;
                episode.EpisodeType = type;
                episode.Title = title;
                updateContext.Entry(episode).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateEpisode(int episodeId, int seriesNumber, int episodeNumber, EpisodeType type, string title,
        DateTime date)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
        if (episode != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                episode.SeriesNumber = seriesNumber;
                episode.EpisodeNumber = episodeNumber;
                episode.EpisodeType = type;
                episode.Title = title;
                episode.EpisodeDate = date;
                updateContext.Entry(episode).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateEpisode(int episodeId, int seriesNumber, int episodeNumber, EpisodeType type, string title,
        DateTime date, string note)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
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
                updateContext.SaveChanges();
            }
    }

    public void UpdateEpisode(int episodeId, int seriesNumber, int episodeNumber, EpisodeType type, string title,
        DateTime date, string? note, int authorId)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
        var author = _context.tblAuthors.Find(authorId);
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
                updateContext.SaveChanges();
            }
    }

    public void UpdateEpisode(int episodeId, int seriesNumber, int episodeNumber, EpisodeType type, string title,
        DateTime date, string? note, int authorId, int doctorId)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
        var author = _context.tblAuthors.Find(authorId);
        var doctor = _context.tblDoctors.Find(doctorId);
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
                updateContext.SaveChanges();
            }
    }

    public void DeleteEpisode(int episodeId)
    {
        var episode = _context.tblEpisodes.Find(episodeId);
        if (episode != null)
            using (var deleteContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                deleteContext.tblEpisodes.Remove(episode);
                deleteContext.SaveChanges();
            }
    }
}