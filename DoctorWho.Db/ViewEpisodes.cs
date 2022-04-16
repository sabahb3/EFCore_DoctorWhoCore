using DoctorWho.Db.Enumerations;
namespace DoctorWho.Db;

public class ViewEpisodes
{
    public int EpisodeId { get; set; }
    public int SeriesNumber { get; set; }
    public int EpisodeNumber { get; set; }
    public string EpisodeType { get; set; }
    public string Title { get; set; }
    public DateTime? EpisodeDate { get; set; }
    public string? Note { get; set; }
    public string AuthorName { get; set; }
    public string DoctorName { get; set; }
    public string? Companions { get; set; }
    public string? Enemies { get; set; }
}