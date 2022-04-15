namespace DoctorWho.Db;

public class Enemy
{
    public Enemy()
    {
        EpisodesEnemies = new List<EpisodeEnemy>();
    }
    public int EnemyId { get; set; }
    public string EnemyName { get; set; }
    public string Description { get; set; }
    
    public ICollection<EpisodeEnemy> EpisodesEnemies { get; set; }

}