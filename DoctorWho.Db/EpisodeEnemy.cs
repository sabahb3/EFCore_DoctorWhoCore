namespace DoctorWho.Db;

public class EpisodeEnemy
{
    public int EpisodeId { get; set; }
    public int EnemyId { get; set; }

    public Episode Episode { get; set; }
    public Enemy Enemy { get; set; }   
}