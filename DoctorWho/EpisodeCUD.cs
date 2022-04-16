using DoctorWho.Db;
using DoctorWho.Db.Enumerations;
using Microsoft.EntityFrameworkCore;
namespace DoctorWho;

public class EpisodeCUD
{
    private static DoctorWhoDbContext _context = new();
    public static void CreateEpisode(Episode episode)
    {
        var author = _context.tblAuthors.Find(episode.AuthorId);
        var doctor = _context.tblDoctors.Find(episode.DoctorId);
        if(author!=null&& doctor != null)
        {
            _context.tblEpisodes.Add(episode);
            _context.SaveChanges();            
        }

    }
}