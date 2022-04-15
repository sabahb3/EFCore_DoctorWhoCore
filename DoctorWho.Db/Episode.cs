using DoctorWho.Db.Enumerations;
namespace DoctorWho.Db;

public class Episode
{
    public int EpisodeId { get; set; }
    public int SeriesNumber { get; set; }
    public int EpisodeNumber { get; set; }
    public EpisodeType EpisodeType { get; set; }
    public string Title { get; set; }
    public DateTime EpisodeDate { get; set; }
    public string Note { get; set; }
    public int AuthorId { get; set; }
    public int DoctorId { get; set; }
}