namespace DoctorWho.Db;

public class Companion
{
    public Companion()
    {
        EpisodesCompanions = new List<EpisodeCompanion>();
    }

    public int CompanionId { get; set; }
    public string CompanionName { get; set; }
    public string WhoPlayed { get; set; }

    public ICollection<EpisodeCompanion> EpisodesCompanions { get; set; }
}